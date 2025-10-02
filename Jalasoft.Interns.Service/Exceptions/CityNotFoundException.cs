using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.Service.Exceptions
{
    public class CityNotFoundException : InternsException
    {
        public CityNotFoundException(int cityId)
            : base($"City with id: {cityId}, not found")
        {
        }
    }
}
