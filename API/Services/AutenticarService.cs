using API.DTOs;
using API.Enums;
using API.Interfaces;
using AutoMapper;
using System.Security.Claims;
using static Biblioteca.Utils;

namespace API.Services
{
    public class AutenticarService : IAutenticarService
    {
        private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IMapper _map;

        public AutenticarService(IJwtTokenGeneratorService jwtTokenGeneratorService, IUsuarioRepository usuarioRepository, IRefreshTokenRepository refreshTokenRepository, IMapper map)
        {
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
            _usuarioRepository = usuarioRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _map = map;
        }

        public async Task<UsuarioDTO> Login(UsuarioSenhaDTO dto)
        {
            // #1 - Verificar se o usuário existe;
            var usuario = await _usuarioRepository.GetByEmailOuUsuarioSistema(dto?.Email, dto?.NomeUsuarioSistema);

            if (usuario is null)
            {
                UsuarioDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.UsuarioNaoEncontrado, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.UsuarioNaoEncontrado) };
                return erro;
            }

            // #2 - Verificar se a senha está correta;
            if (usuario.Senha != Criptografar(dto?.Senha))
            {
                UsuarioDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.UsuarioSenhaIncorretos, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.UsuarioSenhaIncorretos) };
                return erro;
            }

            // #3 - Verificar se o usuário está ativo;
            if (!usuario.IsAtivo)
            {
                UsuarioDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.ContaDesativada, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.ContaDesativada) };
                return erro;
            }

            // #4 - Criar token JWT;
            var token = _jwtTokenGeneratorService.GerarToken(usuario, null);
            usuario.Token = token;

            // #5 - Gerar refresh token;
            var refreshToken = _jwtTokenGeneratorService.GerarRefreshToken();
            usuario.RefreshToken = refreshToken;

            RefreshTokenDTO novoRefreshToken = new()
            {
                RefToken = refreshToken,
                UsuarioId = usuario.UsuarioId,
                DataRegistro = HorarioBrasilia()
            };

            await _refreshTokenRepository.Adicionar(novoRefreshToken);

            // #6 - Converter de UsuarioSenhaDTO para UsuarioDTO;
            UsuarioDTO usuarioDTO = _map.Map<UsuarioDTO>(usuario);

            return usuarioDTO;
        }

        public async Task<UsuarioDTO> Registrar(UsuarioSenhaDTO dto)
        {
            // #1 - Verificar se o usuário já existe com o e-mail ou nome de usuário do sistema informados. Se existir, aborte;
            var verificarUsuario = await _usuarioRepository.GetByEmailOuUsuarioSistema(dto?.Email, dto?.NomeUsuarioSistema);

            if (verificarUsuario is not null)
            {
                UsuarioDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.UsuarioExistente, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.UsuarioExistente) };
                return erro;
            }

            // #2.1 - Verificar requisitos gerais;
            if (dto?.NomeCompleto?.Length < 3 || dto?.NomeUsuarioSistema?.Length < 3)
            {
                UsuarioDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.RequisitosNome, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.RequisitosNome) };
                return erro;
            }

            // #2.2 - Verificar e-mail;
            if (!ValidarEmail(dto?.Email))
            {
                UsuarioDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.EmailInvalido, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.EmailInvalido) };
                return erro;
            }

            // #2.3 - Verificar requisitos de senha;
            var validarSenha = ValidarSenha(dto?.Senha, dto?.NomeCompleto, dto?.NomeUsuarioSistema, dto?.Email);
            if (!validarSenha.Item1)
            {
                UsuarioDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.RequisitosSenhaNaoCumprido, MensagemErro = validarSenha.Item2 };
                return erro;
            }

            // #3.1 - Gerar código de verificação para usar no processo de criação e no envio de e-mail;
            string codigoVerificacao = GerarStringAleatoria(6, true);

            // #3.2 - Criar usuário;
            var novoUsuario = new UsuarioSenhaDTO
            {
                NomeCompleto = dto?.NomeCompleto,
                Email = dto?.Email,
                NomeUsuarioSistema = dto?.NomeUsuarioSistema,
                Senha = Criptografar(dto?.Senha ?? ""),
                UsuarioTipoId = (int)UsuarioTipoEnum.Usuario,
                DataRegistro = HorarioBrasilia(),
                IsAtivo = true
            };

            UsuarioDTO usuarioAdicionado = await _usuarioRepository.Adicionar(novoUsuario);

            // #4 - Adicionar ao objeto novoUsuario o id do novo usuário;
            novoUsuario.UsuarioId = usuarioAdicionado.UsuarioId;

            // #5 - Criar token JWT;
            var token = _jwtTokenGeneratorService.GerarToken(novoUsuario, null);
            novoUsuario.Token = token;

            // #6 - Gerar refresh token;
            var refreshToken = _jwtTokenGeneratorService.GerarRefreshToken();
            novoUsuario.RefreshToken = refreshToken;

            RefreshTokenDTO novoRefreshToken = new()
            {
                RefToken = refreshToken,
                UsuarioId = usuarioAdicionado.UsuarioId,
                DataRegistro = HorarioBrasilia()
            };

            await _refreshTokenRepository.Adicionar(novoRefreshToken);

            // #7 - Converter de UsuarioSenhaDTO para UsuarioDTO;
            UsuarioDTO usuarioDTO = _map.Map<UsuarioDTO>(novoUsuario);

            return usuarioDTO;
        }

        public async Task<UsuarioDTO> RefreshToken(string token, string refreshToken)
        {
            var principal = _jwtTokenGeneratorService.GetInfoTokenExpirado(token);
            int usuarioId = Convert.ToInt32(principal?.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).FirstOrDefault());

            var refreshTokenSalvoAnteriormente = await _refreshTokenRepository.GetRefreshTokenByUsuarioId(usuarioId);

            if (refreshTokenSalvoAnteriormente != refreshToken)
            {
                UsuarioDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.RefreshTokenInvalido, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.RefreshTokenInvalido) };
                return erro;
            }

            var novoToken = _jwtTokenGeneratorService.GerarToken(null, principal?.Claims);
            var novoRefreshToken = _jwtTokenGeneratorService.GerarRefreshToken();

            // Criar novo registro com o novo refresh token gerado;
            RefreshTokenDTO novoRefreshTokenDTO = new()
            {
                RefToken = novoRefreshToken,
                UsuarioId = usuarioId,
                DataRegistro = HorarioBrasilia()
            };

            await _refreshTokenRepository.Adicionar(novoRefreshTokenDTO);

            // Retornar o novo token e o novo refresh token;
            UsuarioDTO dto = new()
            {
                Token = novoToken,
                RefreshToken = novoRefreshToken
            };

            return dto;
        }
    }
}
