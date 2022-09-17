using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ApiCityEvents.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private readonly IConfiguration _configuration;

        public EventReservationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool InsertNewEventReservation(int index, EventReservation eventReservation)
        {
            var queryInsert = $"INSERT INTO EventReservation (IdEvent,PersonName,Quantity) " +
                $"VALUES (@IdEvent,@PersonName,@Quantity)";

            var parameters = new DynamicParameters();
            parameters.Add("IdEvent", index);
            parameters.Add("PersonName", eventReservation.PersonName);
            parameters.Add("Quantity", eventReservation.Quantity);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection")); 

            return conn.Execute(queryInsert, parameters) == 1;
            return conn.Execute(queryInsert, parameters) == 1;
        }

        public bool CheckIfExistsReservationForUpdate(int index, EventReservation eventReservation)
        {
            var query = "SELECT IdReservation " +
                "FROM EventReservation WHERE PersonName = @PersonName AND Quantity = @Quantity AND IdEvent = @IdEvent";

            var parameters = new DynamicParameters();
            parameters.Add("PersonName", eventReservation.PersonName);
            parameters.Add("Quantity", eventReservation.Quantity);
            parameters.Add("IdEvent", index);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            var CheckCityEvent = conn.QueryFirstOrDefault(query, parameters);

            return !(CheckCityEvent is null);
        }
        public bool UpdateEventRespositoryQuantity(int index, long newQuantity,EventReservation eventReservation)
        {
            var queryUpdateQuatity = "UPDATE EventReservation " +
                     "SET  PersonName = @PersonName, Quantity = @newQuantity " +
                     "WHERE PersonName = @PersonName AND Quantity = @Quantity AND IdEvent = @IdEvent";

            var parameters = new DynamicParameters();
            parameters.Add("PersonName", eventReservation.PersonName);
            parameters.Add("Quantity", eventReservation.Quantity);
            parameters.Add("newQuantity", newQuantity);
            parameters.Add("IdEvent", index);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.Execute(queryUpdateQuatity, parameters) == 1;
        }

        public bool DeleteEventReservation(int index, EventReservation eventReservation)
        {
            var queryDelete = "DELETE " +
                "FROM EventReservation WHERE PersonName = @PersonName AND Quantity = @Quantity AND IdEvent = @IdEvent";

            var parameters = new DynamicParameters();
            parameters.Add("PersonName", eventReservation.PersonName);
            parameters.Add("Quantity", eventReservation.Quantity);
            parameters.Add("IdEvent", index);


            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.Execute(queryDelete, parameters) == 1;
        }


        public List<dynamic> QueryEventReservationForPersonNameAndTitleEvent(string personName, string titleEvent)
        {
            var query = "  SELECT a.IdReservation, a.IdEvent, b.Title, a.PersonName, a.Quantity  " +
                "FROM EventReservation a  INNER JOIN CityEvent b  ON a.IdEvent = b.IdEvent  " +
                "WHERE A.PersonName = @PersonName AND b.Title LIKE @Title";

            var parameters = new DynamicParameters();
            parameters.Add("Title", "%" + titleEvent + "%");
            parameters.Add("PersonName", personName);

            using var conn = new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));

            return conn.Query(query, parameters).ToList();
        }



    }
}
