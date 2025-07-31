namespace WebApplication4.Services.Implementations
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}