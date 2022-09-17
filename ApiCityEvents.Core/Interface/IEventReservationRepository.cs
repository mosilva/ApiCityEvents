using ApiCityEvents.Core.Model;

namespace ApiCityEvents.Core.Interface
{
    public interface IEventReservationRepository
    {
        bool InsertNewEventReservation(int index, EventReservation eventReservation);

        bool CheckIfExistsReservationForUpdate(int index, EventReservation eventReservation);

        bool UpdateEventRespositoryQuantity(int index, long newQuantity, EventReservation eventReservation);

        bool DeleteEventReservation(int index, EventReservation eventReservation);

        List<dynamic> QueryEventReservationForPersonNameAndTitleEvent(string personName, string titleEvent);

    }
}
