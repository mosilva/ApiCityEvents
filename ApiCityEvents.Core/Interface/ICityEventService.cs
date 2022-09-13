using ApiCityEvents.Core.Model;

namespace ApiCityEvents.Core.Interface
{
    public interface ICityEventService
    {
        bool CreateCityEvent(CityEvent cityEvent);
        bool CheckConflictCityEventInsert(CityEvent cityEvent);
    }
}
