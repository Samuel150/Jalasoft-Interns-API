using AutoMapper;
using Jalasoft.Interns.API.Requests.Cities;
using Jalasoft.Interns.API.Responses.Cities;
using Jalasoft.Interns.Service.Domain.Cities;

namespace Jalasoft.Interns.API.Adapter
{
    public interface ICityAdapter
    {
        public City AdaptCityDtoToCity(CityResponseDto city);
        public CityResponseDto AdaptCityToCityDto(City city);
        public City AdaptUpdateCityToCity(UpdateCityRequestDto city);
        public City AdaptCreateCityDtoToCity(CreateCityRequestDto city);
        public Hospital AdaptCreateHospitalDtoToHospital(CreateHospitalRequestDto createHospitalRequestDto);
        public HospitalResponseDto AdaptHospitalToHospitalDto(Hospital hospital);
        public IEnumerable<HospitalResponseDto> AdaptHospitalsToHospitalDtos(IEnumerable<Hospital> hospitals);

    }
    public class CityAdapter : ICityAdapter
    {
        private readonly IMapper _mapper;

        public CityAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }
        public City AdaptCityDtoToCity(CityResponseDto city)
        {
            return _mapper.Map<City>(city);
        }

        public CityResponseDto AdaptCityToCityDto(City city)
        {
            return _mapper.Map<CityResponseDto>(city);
        }
        public City AdaptCreateCityDtoToCity(CreateCityRequestDto city)
        {
            return _mapper.Map<City>(city); 
        }


        public City AdaptUpdateCityToCity(UpdateCityRequestDto city)
        {
            return _mapper.Map<City>(city);
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
    }
}
