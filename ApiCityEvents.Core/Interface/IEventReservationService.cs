using ApiCityEvents.Core.Model;

namespace ApiCityEvents.Core.Interface
{
    public interface IEventReservationService
    {
        bool CreateEventReservation(int index,EventReservation EventReservation);

        bool CheckIfExistsReservation(int index, EventReservation eventReservation);

        bool UpdateEventRespositoryQuantity(int index, long newQuantity, EventReservation eventReservation);

        bool DeleteEventReservation(int index, EventReservation eventReservation);

        List<dynamic> QueryCityEventReservation(string personName, string titleEvent);
    }
}
