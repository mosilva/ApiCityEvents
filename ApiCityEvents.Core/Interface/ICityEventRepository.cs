using ApiCityEvents.Core.Model;

namespace ApiCityEvents.Core.Interface
{
    public interface ICityEventRepository
    {
        bool InsertNewCityEvent(CityEvent cityEvent);

        bool CheckConflictCityEventInsert(CityEvent cityEvent);

        bool CheckIfExistsCityEventForId(int index);

        bool UpdateCityEvent(int index, CityEvent cityEvent);

        bool UpdateCityEvent(int index, bool status);

        bool CheckIfExistsReservationForCityEvent(int index);

        bool DeleteCityEvent(int index);
        List<CityEvent> QueryCityEvent(string title);

        List<CityEvent> QueryCityEvent(string local, DateTime date);

        List<CityEvent> QueryCityEvent(decimal inicialPrice, decimal finalPrice, DateTime date);

    }
}
