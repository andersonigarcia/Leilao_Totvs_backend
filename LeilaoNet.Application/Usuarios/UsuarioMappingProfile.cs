using AutoMapper;
using LeilaoNet.Application.Usuarios.Queries.Responses;
using LeilaoNet.Domain.Models;

namespace LeilaoNet.Application.Produtos
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, LoginResponse>();
            CreateMap<Usuario, LogoutResponse>();
        }
    }
}
