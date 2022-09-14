using ApiCityEvents.Core.Model;

namespace ApiCityEvents.Core.Interface
{
    public interface ICityEventService
    {
        bool CreateCityEvent(CityEvent cityEvent);
        bool CheckExictsCityEvent(CityEvent cityEvent);
        bool CheckExictsCityEvent(int index);
        bool UpdateCityEvent(int index, CityEvent cityEvent);

        bool UpdateCityEvent(int index, bool status);

        bool CheckExictsReservationForCityEvent(int index);

        bool DeleteCityEvent(int index);
        List<CityEvent> SelectCityEvent(string title);

        List<CityEvent> SelectCityEvent(string local, string date);

        List<CityEvent> SelectCityEvent(decimal inicialPrice, decimal finalPrice, string date);
    }
}
