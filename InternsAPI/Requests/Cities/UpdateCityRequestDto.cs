using Jalasoft.Interns.Service.Domain.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.API.Requests.Cities
{
    public class UpdateCityRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public long GPD { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public bool Capitalist { get; set; }
        public IEnumerable<Hospital> Hospitals { get; set; } = Enumerable.Empty<Hospital>();

    }
}
