using AutoMapper;
using Jalasoft.Interns.API.Requests.Cities;
using Jalasoft.Interns.API.Responses.Cities;
using Jalasoft.Interns.Service.Domain.Cities;

namespace Jalasoft.Interns.API.Adapter
{
    public interface ICityAdapter
    {
        public City AdaptCityDtoToCity(DefaultCityResponseDto city);
        public DefaultCityResponseDto AdaptCityToCityDto(City city);
        public City AdaptUpdateCityToCity(UpdateCityRequestDto city);
        public City AdaptCreateCityDtoToCity(CreateCityRequestDto city);
        Hospital AdaptCreateHospitalDtoToHospital(CreateHospitalRequestDto createHospitalRequestDto);
        HospitalResponseDto AdaptHospitalToHospitalDto(Hospital hospital);
        IEnumerable<HospitalResponseDto> AdaptHospitalsToHospitalDtos(IEnumerable<Hospital> hospitals);

    }
    public class CityAdapter : ICityAdapter
    {
        private readonly IMapper _mapper;

        public CityAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }
        public City AdaptCityDtoToCity(DefaultCityResponseDto city)
        {
            Console.WriteLine(city.Id);

            return new City()
            {
                Id = city.Id,
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist= city.Capitalist,
                Hospitals = city.Hospitals,
            };
        }

        public DefaultCityResponseDto AdaptCityToCityDto(City city)
        {
            return new DefaultCityResponseDto()
            {
                Id = city.Id,
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist = city.Capitalist,
                Hospitals = city.Hospitals,
            };
        }
        public City AdaptCreateCityDtoToCity(CreateCityRequestDto city)
        {
            return new City()
            {
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist = city.Capitalist,
                Hospitals = MapHospitalsFromRequest(city.Hospitals),

            };
        }


        public City AdaptUpdateCityToCity(UpdateCityRequestDto city)
        {
            return new City()
            {
                Name = city.Name,
                Capital = city.Capital,
                Country = city.Country,
                GPD = city.GPD,
                Capitalist = city.Capitalist,
                Hospitals = city.Hospitals,
            };
        }

        public Hospital AdaptCreateHospitalDtoToHospital(CreateHospitalRequestDto createHospitalRequestDto)
        {
            return _mapper.Map<Hospital>(createHospitalRequestDto);
        }

        public HospitalResponseDto AdaptHospitalToHospitalDto(Hospital hospital)
        {
            return _mapper.Map<HospitalResponseDto>(hospital);
        }

        public IEnumerable<HospitalResponseDto> AdaptHospitalsToHospitalDtos(IEnumerable<Hospital> hospitals)
        {
            return hospitals.Select(h => _mapper.Map<HospitalResponseDto>(h));
        }
        private IList<Hospital> MapHospitalsFromRequest(IList<CreateHospitalRequestDto> hospitals)
        {
            if (hospitals == null || !hospitals.Any())
                return new List<Hospital>();

            return hospitals.Select(h => new Hospital()
            {
                Name = h.Name,
                Address = h.Address
            }).ToList();
        }
    }
}
