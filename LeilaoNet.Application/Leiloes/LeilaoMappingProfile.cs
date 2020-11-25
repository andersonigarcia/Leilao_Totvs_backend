using AutoMapper;
using LeilaoNet.Application.Clients.Commands;
using LeilaoNet.Application.Leiloes.Queries.Responses;
using LeilaoNet.Domain.Models;

namespace LeilaoNet.Application.Leiloes
{
    public class LeilaoMappingProfile : Profile
    {
        public LeilaoMappingProfile()
        {
            CreateMap<LeilaoCreateCommand, Leilao>();
            CreateMap<LeilaoUpdateCommand, Leilao>();
            
            CreateMap<Leilao, GetAllLeiloesResponse>();
            CreateMap<Leilao, GetLeilaoByIdResponse>();
        }
    }
}