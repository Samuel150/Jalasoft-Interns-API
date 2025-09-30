using Jalasoft.Interns.Service.Domain.Cities;

namespace Jalasoft.Interns.API.Responses.Cities
{
    public class PatchCityResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long GPD { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public bool Capitalist { get; set; }
        public IList<Hospital> Hospitals { get; set; }
    }
}
