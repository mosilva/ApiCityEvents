namespace ApiCityEvents.Core.Interface
{
    public interface ITokenService
    {
        string GenerateTokenEvents(string nome, string permissao);

    }
}
