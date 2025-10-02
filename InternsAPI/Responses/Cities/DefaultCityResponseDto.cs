using Jalasoft.Interns.Service.Domain.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Interns.API.Responses.Cities;

public class DefaultCityResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long GPD { get; set; }
    public string Country { get; set; } = string.Empty;
    public string Capital { get; set; } = string.Empty;
    public bool Capitalist { get; set; }
    public IList<Hospital> Hospitals { get; set; }
}
public class HospitalResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}
