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

            // Outros;
            CreateMap<Mensagem, MensagemDTO>().ReverseMap();
        }
    }
}
