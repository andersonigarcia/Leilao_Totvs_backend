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
    public class AuthenticationUserQueryHandler : CommandHandler, IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly IUsuarioRepository _clientRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationUserQueryHandler(IUsuarioRepository clientRepository, IConfiguration configuration)
            : base(clientRepository.UnitOfWork)
        {
            _clientRepository = clientRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _clientRepository.GetFirstAsync(x => x.Nome.ToLower() == request.Username.ToLower() && x.Senha.ToLower() == request.Password.ToLower());

            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret:Hash").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user.Nome) }),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponse(user.Nome, tokenHandler.WriteToken(token));
        }
    }
}