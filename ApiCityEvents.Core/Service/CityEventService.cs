using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Model;

namespace ApiCityEvents.Core.Service
{
    public class CityEventService : ICityEventService
    {
        private readonly ICityEventRepository _cityEventRepository;

        public CityEventService(ICityEventRepository cityEventRepository)
        {
            _cityEventRepository = cityEventRepository;
        }

        public bool CreateCityEvent(CityEvent cityEvent)
        {
            return _cityEventRepository.InsertNewCityEvent(cityEvent);
        }

        public bool CheckExictsCityEvent(CityEvent cityEvent)
        {
            return _cityEventRepository.CheckConflictCityEventInsert(cityEvent);
        }

        public bool CheckExictsCityEvent(int index)
        {
            return _cityEventRepository.CheckIfExistsCityEventForId(index);
        }

        public bool UpdateCityEvent(int index, CityEvent cityEvent)
        {
            return _cityEventRepository.UpdateCityEvent(index, cityEvent);
        }

        public bool UpdateCityEvent(int index, bool status)
        {
            return _cityEventRepository.UpdateCityEvent(index, status);
        }

        public bool CheckExictsReservationForCityEvent(int index)
        {
            return _cityEventRepository.CheckIfExistsReservationForCityEvent(index);
        }

        public bool DeleteCityEvent(int index)
        {
            return _cityEventRepository.DeleteCityEvent(index);
        }

        public List<CityEvent> SelectCityEvent(string title)
        {
            return _cityEventRepository.QueryCityEvent(title);
        }

        public List<CityEvent> SelectCityEvent(string local, DateTime date)
        {
            return _cityEventRepository.QueryCityEvent(local, date);
        }

        public List<CityEvent> SelectCityEvent(decimal inicialPrice
            , decimal finalPrice
            , DateTime date)
        {
            return _cityEventRepository.QueryCityEvent(inicialPrice, finalPrice, date);
        }

    }
}
