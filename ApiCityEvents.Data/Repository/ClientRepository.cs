using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ApiCityEvents.Data.Repository
{

    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration _configuration;

        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Client> GetByCpfAsync(string cpf)
        {
            var query = "SELECT * FROM clientes where cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("AuthorizantionConnection"));

            return await conn.QueryFirstOrDefaultAsync<Client>(query, parameters);
        }

    }
}
