using ApiCityEvents.Core.Model;

namespace ApiCityEvents.Core.Interface
{

    public interface IClientRepository
    {
        Task<Client> GetByCpfAsync(string cpf);
    }
}
