namespace LeilaoNet.Application.Usuarios.Queries.Responses
{
    public class LogoutResponse : UsuarioResponse
    {
        public LogoutResponse(string username, string token)
        {
            Token = token;
            Nome = username;
        }
        public string Token { get; set; }
    }
}
