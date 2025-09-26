using Jalasoft.Interns.API.Adapter;
using Jalasoft.Interns.API.Requests.Cities;
using Jalasoft.Interns.Service.Cities.Interfaces;
using Jalasoft.Interns.Service.Domain.Cities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Jalasoft.Interns.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController(ILogger<CitiesController> _logger, ICityAdapter _cityAdapter, ICityService _cityService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCitites([FromQuery] bool capitalist)
        {
            _logger.Log(LogLevel.Information, "Retrieving Cities");
            var cities = _cityService.GetAll(capitalist);
            return Ok(cities);
        }
        [HttpGet("/{id}")]
        public IActionResult GetCity(int id)
        {
            _logger.Log(LogLevel.Information, "Retrieving City");
            var city = _cityService.GetById(id);
            return Ok(_cityAdapter.AdaptCityToCityDto(city));
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] CreateCityDto request)
        {
            _logger.Log(LogLevel.Information, "Create Cities");
            var newCity = _cityAdapter.AdaptCreateCityDtoToCity(request);
            var createdCity = _cityService.Create(newCity);
            return Created("", _cityAdapter.AdaptCityToCityDto(createdCity));
        }

        [HttpPut]
        public IActionResult PutCity([FromBody] UpdateCityDto request, [FromQuery] int id)
        {
            _logger.Log(LogLevel.Information, "Updated Cities");
            var newCity = _cityAdapter.AdaptUpdateCityToCity(request);
            var updatedCity = _cityService.Update(id, newCity);
            return Ok(_cityAdapter.AdaptCityToCityDto(updatedCity));
        }
    }
}
