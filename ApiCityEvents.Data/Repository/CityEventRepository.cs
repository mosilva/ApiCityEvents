using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ApiCityEvents.Data.Repository
{
    public class CityEventRepository : ICityEventRepository
    {
        private readonly IConfiguration _configuration;

        public CityEventRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool InsertNewCityEvent(CityEvent cityEvent)
        {
            var queryInsert = $"INSERT CityEvent VALUES" +
                $" (@Title" +
                $",@Description" +
                $",@DateHourEvent" +
                $",@Local" +
                $",@Address" +
                $",@Price" +
                $",@Status)";

            var parameters = new DynamicParameters();
            parameters.Add("Title", cityEvent.Title);
            parameters.Add("Description", cityEvent.Title);
            parameters.Add("DateHourEvent", cityEvent.Title);
            parameters.Add("Local", cityEvent.Title);
            parameters.Add("Address", cityEvent.Title);
            parameters.Add("Price", cityEvent.Title);
            parameters.Add("Price", cityEvent.Title);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.Execute(queryInsert, parameters) == 1;
        }

        public bool CheckConflictCityEventInsert(CityEvent cityEvent)
        {
            var queryValidationConflit = "SELECT Title" +
              "FROM CityEvent WHERE Title = @Title" +
              "AND DateHourEvent = @DateHourEvent" +
              "AND Local = @Local";

            var parameters = new DynamicParameters();
            parameters.Add("Title", cityEvent.Title);
            parameters.Add("DateHourEvent", cityEvent.Title);
            parameters.Add("Local", cityEvent.Title);
            parameters.Add("Address", cityEvent.Title);
            parameters.Add("Price", cityEvent.Title);
            parameters.Add("Price", cityEvent.Title);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.QueryFirst(queryValidationConflit, parameters) == 1;
        }
    }
}
