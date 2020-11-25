using FluentValidation.Results;
using LeilaoNet.Application.Clients.Commands;
using LeilaoNet.Application.Clients.Handlers;
using LeilaoNet.Application.Leiloes.Queries;
using LeilaoNet.Application.Leiloes.Queries.Responses;
using LeilaoNet.Application.Usuarios.Queries;
using LeilaoNet.Application.Usuarios.Queries.Responses;
using LeilaoNet.Data.Repositories;
using LeilaoNet.Data.Repository;
using LeilaoNet.Domain.Interfaces.Data;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace LeilaoNet.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(new JsonSerializer
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            // Domain - Commands            
            #region Leilão Commands

            services.AddTransient<IRequestHandler<LeilaoCreateCommand, ValidationResult>, LeilaoCreateCommandHandler>();
            services.AddTransient<IRequestHandler<LeilaoUpdateCommand, ValidationResult>, LeilaoUpdateCommandHandler>();
            services.AddTransient<IRequestHandler<LeilaoDeleteCommand, ValidationResult>, LeilaoDeleteCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllLeilaoQuery, IEnumerable<GetAllLeiloesResponse>>, GetAllLeiloesQueryHandler>();
            services.AddTransient<IRequestHandler<GetLeilaoByIdQuery, GetLeilaoByIdResponse>, GetLeilaoByIdQueryHandler>();

            #endregion


            #region Usuário Commands

            //services.AddTransient<IRequestHandler<UsuarioCreateCommand, ValidationResult>, UsuarioCreateCommandHandler>();
            //services.AddTransient<IRequestHandler<LeilaoUpdateCommand, ValidationResult>, LeilaoUpdateCommandHandler>();
            //services.AddTransient<IRequestHandler<LeilaoDeleteCommand, ValidationResult>, LeilaoDeleteCommandHandler>();
            //services.AddTransient<IRequestHandler<GetAllLeilaoQuery, IEnumerable<GetAllLeiloesResponse>>, GetAllLeiloesQueryHandler>();
            services.AddTransient<IRequestHandler<LoginQuery, LoginResponse>, AuthenticationUserQueryHandler>();
            services.AddTransient<IRequestHandler<LogoutQuery, LogoutResponse>, LogoutUserQueryHandler>();

            #endregion


            // Data
            services.AddTransient<ILeilaoRepository, LeilaoRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
    }
}