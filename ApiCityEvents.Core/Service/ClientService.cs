using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Model;

namespace ApiCityEvents.Core.Service
{

    public class ClientService : IClientService
    {

        public IClientRepository _clienteRespository;
        public ClientService(IClientRepository clienteRespository)
        {
            _clienteRespository = clienteRespository;
        }

        public async Task<Client> GetByCpfAsync(string cpf)
        {
            return await _clienteRespository.GetByCpfAsync(cpf);
        }

    }
}
