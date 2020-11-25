using LeilaoNet.Application.Usuarios.Queries;
using LeilaoNet.Application.Usuarios.Queries.Responses;
using LeilaoNet.Domain.Core.Messaging;
using LeilaoNet.Domain.Interfaces.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeilaoNet.Application.Clients.Handlers
{
    public class LogoutUserQueryHandler : CommandHandler, IRequestHandler<LogoutQuery, LogoutResponse>
    {
        private readonly IConfiguration _configuration;
        public LogoutUserQueryHandler(IUsuarioRepository clientRepository, IConfiguration configuration) : base(clientRepository.UnitOfWork)
        {
            _configuration = configuration;
        }

        public async Task<LogoutResponse> Handle(LogoutQuery request, CancellationToken cancellationToken)
        {
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret:Hash").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, request.Username) }),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddSeconds(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() => tokenHandler.CreateToken(tokenDescriptor));

            return new LogoutResponse(request.Username, tokenHandler.WriteToken(token));
        }
    }
}