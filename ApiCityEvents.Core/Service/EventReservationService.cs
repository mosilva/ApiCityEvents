using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Model;

namespace ApiCityEvents.Core.Service
{
    public class EventReservationService : IEventReservationService
    {
        private readonly IEventReservationRepository _eventReservationRepository;
        public EventReservationService(IEventReservationRepository eventReservationRepository)
        {
            _eventReservationRepository = eventReservationRepository;
        }

        public bool CreateEventReservation(int index, EventReservation EventReservation)
        {
            return _eventReservationRepository.InsertNewEventReservation(index,EventReservation);
        }

        public bool CheckIfExistsReservation(int index, EventReservation eventReservation)
        {
            return _eventReservationRepository.CheckIfExistsReservationForUpdate(index, eventReservation);

        }

        public bool UpdateEventRespositoryQuantity(int index, long newQuantity, EventReservation eventReservation)
        {
            return _eventReservationRepository.UpdateEventRespositoryQuantity(index, newQuantity, eventReservation);
        }

        public bool DeleteEventReservation(int index, EventReservation eventReservation)
        {
            return _eventReservationRepository.DeleteEventReservation(index, eventReservation);

        }

        public List<dynamic> QueryCityEventReservation(string personName, string titleEvent)
        {
            return _eventReservationRepository.QueryEventReservationForPersonNameAndTitleEvent(personName, titleEvent);
        }
    }
}
