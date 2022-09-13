using ApiCityEvents.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCityEvents.Core.Interface
{
    public interface ICityEventRepository
    {
        bool InsertNewCityEvent(CityEvent cityEvent);

        bool CheckConflictCityEventInsert(CityEvent cityEvent);


    }
}
