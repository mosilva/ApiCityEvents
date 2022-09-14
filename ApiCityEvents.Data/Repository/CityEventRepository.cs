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
            parameters.Add("Description", cityEvent.Description);
            parameters.Add("DateHourEvent", cityEvent.DateHourEvent);
            parameters.Add("Local", cityEvent.Local);
            parameters.Add("Address", cityEvent.Address);
            parameters.Add("Price", cityEvent.Price);
            parameters.Add("Status", cityEvent.Status);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.Execute(queryInsert, parameters) == 1;
        }

        public bool CheckConflictCityEventInsert(CityEvent cityEvent)
        {
            var queryValidationConflict = "SELECT Title " +
              "FROM CityEvent WHERE Title = @Title " +
              "AND DateHourEvent = @DateHourEvent ";

            var parameters = new DynamicParameters();
            parameters.Add("Title", cityEvent.Title);
            parameters.Add("DateHourEvent", cityEvent.DateHourEvent);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            var cityEventTest = conn.QueryFirstOrDefault(queryValidationConflict, parameters);

            return cityEventTest is null;
        }

        public bool CheckIfExistsCityEventForId(int index)
        {
            var query = "SELECT Title " +
                "FROM CityEvent WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("idEvent", index);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            var CheckCityEvent = conn.QueryFirstOrDefault(query, parameters);

            return CheckCityEvent is null;
        }

        public bool UpdateCityEvent(int index, CityEvent cityEvent)
        {
            var queryUpdateAllFields = "UPDATE CityEvent " +
                "SET " +
                " Title = @Title" +
                ",Description = @Description" +
                ",DateHourEvent = @DateHourEvent" +
                ",Local = @Local" +
                ",Address = @Address" +
                ",Price = @Price" +
                ",Status = @Status " +
                "WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("idEvent", index);
            parameters.Add("Title", cityEvent.Title);
            parameters.Add("Description", cityEvent.Description);
            parameters.Add("DateHourEvent", cityEvent.DateHourEvent);
            parameters.Add("Local", cityEvent.Local);
            parameters.Add("Address", cityEvent.Address);
            parameters.Add("Price", cityEvent.Price);
            parameters.Add("Status", cityEvent.Status);

            var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.Execute(queryUpdateAllFields, parameters) == 1;

        }

        public bool UpdateCityEvent(int index, bool status)
        {
            var queryUpdateAllFields = "UPDATE CityEvent " +
                "SET " +
                "Status = @Status " +
                "WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("idEvent", index);
            parameters.Add("Status", status);

            var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.Execute(queryUpdateAllFields, parameters) == 1;

        }

        public bool CheckIfExistsReservationForCityEvent(int index)
        {
            var query = "SELECT IdReservation " +
                "FROM EventReservation WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("idEvent", index);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            var CheckCityEvent = conn.QueryFirstOrDefault(query, parameters);

            return !(CheckCityEvent is null);
        }

        public bool DeleteCityEvent(int index)
        {
            var queryDelete = "DELETE FROM CityEvent WHERE idEvent = @idEvent";

            var parameters = new DynamicParameters();
            parameters.Add("idEvent", index);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.Execute(queryDelete, parameters) == 1;
        }

        public List<CityEvent> QueryCityEvent(string title)
        {
            var query = "SELECT * FROM CityEvent WHERE Title LIKE @Title";

            var parameters = new DynamicParameters();
            parameters.Add("Title", "%" + title + "%");

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            var SelectCityEvent = conn.Query<CityEvent>(query, parameters).ToList();

            return SelectCityEvent;
        }

        public List<CityEvent> QueryCityEvent(string local, string date)
        {
            var query = "SELECT * FROM CityEvent WHERE " +
                "Local LIKE @Local " +
                "AND CONVERT(DATE, DateHourEvent, 103)  = CONVERT(DATE,@date, 103) ";

            var parameters = new DynamicParameters();
            parameters.Add("Local", "%" + local + "%");
            parameters.Add("date", date);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.Query<CityEvent>(query, parameters).ToList();
        }

        public List<CityEvent> QueryCityEvent(decimal inicialPrice
            , decimal finalPrice
            , string date)
        {
            var query = "SELECT * FROM CityEvent WHERE " +
                "(Price BETWEEN @inicialPrice AND @finalPrice) " +
                "AND (CONVERT(DATE, DateHourEvent, 103) = CONVERT(DATE,@date, 103))";

            var parameters = new DynamicParameters();
            parameters.Add("inicialPrice", inicialPrice);
            parameters.Add("finalPrice", finalPrice);
            parameters.Add("date", date);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.Query<CityEvent>(query, parameters).ToList();
        }


    }
}
