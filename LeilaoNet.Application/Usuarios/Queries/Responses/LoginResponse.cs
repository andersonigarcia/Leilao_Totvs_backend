namespace LeilaoNet.Application.Usuarios.Queries.Responses
{
    public class LoginResponse : UsuarioResponse
    {
        public LoginResponse(string username, string token)
        {
            Token = token;
            Nome = username;
        }
        public string Token { get; set; }
    }
}
