using AutoMapper;
using LeilaoNet.Application.Produtos.Commands;
using LeilaoNet.Application.Produtos.Queries.Responses;
using LeilaoNet.Application.Usuarios.Queries.Responses;
using LeilaoNet.Domain.Models;

namespace LeilaoNet.Application.Produtos
{
    public class ProdutoMappingProfile : Profile
    {
        public ProdutoMappingProfile()
        {
            CreateMap<ProdutoCreateCommand, Produto>();
            CreateMap<ProdutoUpdateCommand, Produto>();

            CreateMap<Produto, GetAllProdutosResponse>();
            CreateMap<Produto, LoginResponse>();
        }
    }
}
