namespace API.Modules.Account.Ports
{
    public interface IJwtService
    {
        public string CreateToken(string login, string role);
    }
}
