using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.Service.Domain.Cities
{
    public class PatchCity
    {
        public string Name { get; set; } = string.Empty;
        public long GPD { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public bool Capitalist { get; set; }
        public IList<Hospital> Hospitals { get; set; }

    }
}
