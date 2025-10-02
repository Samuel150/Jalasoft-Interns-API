using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.Service.Exceptions
{
    public class HospitalNotFoundException : InternsException
    {
        public HospitalNotFoundException(int cityId, int hospitalId)
            : base($"Hospital with id {hospitalId} not found in city {cityId}")
        {
        }
    }
}
