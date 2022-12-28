using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Outros; 
            CreateMap<RefreshToken, RefreshTokenDTO>().ReverseMap();

            // Usuário e afins;
            CreateMap<UsuarioTipo, UsuarioTipoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioSenhaDTO>().ReverseMap();
            CreateMap<UsuarioSenhaDTO, UsuarioDTO>().ReverseMap();

            // Mensagens, respostas e afins;
            CreateMap<EmocaoTipo, EmocaoTipoDTO>().ReverseMap();
            CreateMap<Mensagem, MensagemDTO>().ReverseMap();
            CreateMap<Resposta, RespostaDTO>().ReverseMap();
            CreateMap<RespostaEmocao, RespostaEmocaoDTO>().ReverseMap();
            CreateMap<MensagemResposta, MensagemRespostaDTO>().ReverseMap();
        }
    }
}
