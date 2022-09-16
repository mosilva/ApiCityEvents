using ApiCityEvents.Core.Model;

namespace ApiCityEvents.Core.Interface
{
    public interface IClientService
    {
        Task<Client> GetByCpfAsync(string cpf);
    }
}
