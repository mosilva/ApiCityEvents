using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCityEvents.Core.Service
{
    public class CityEventService :ICityEventService
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

    }
}
