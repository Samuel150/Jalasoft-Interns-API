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
    public class CitiesController(
        ILogger<CitiesController> logger,
        ICityAdapter cityAdapter,
        ICityService cityService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCitites([FromQuery] bool capitalist)
        {
            logger.Log(LogLevel.Information, "Retrieving Cities");
            var cities = cityService.GetAll(capitalist);
            return Ok(cities);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCity(int id)
        {
            logger.Log(LogLevel.Information, "Retrieving City");
            var city = cityService.GetById(id);
            return Ok(cityAdapter.AdaptCityToCityDto(city));
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] CreateCityDto request)
        {
            logger.Log(LogLevel.Information, "Create Cities");
            var newCity = cityAdapter.AdaptCreateCityDtoToCity(request);
            var createdCity = cityService.Create(newCity);
            return Created("", cityAdapter.AdaptCityToCityDto(createdCity));
        }

        [HttpPut("{id}")]
        public IActionResult PutCity([FromBody] UpdateCityDto request, int id)
        {
            logger.Log(LogLevel.Information, "Updated Cities");
            var newCity = cityAdapter.AdaptUpdateCityToCity(request);
            var updatedCity = cityService.Update(id, newCity);
            return Ok(cityAdapter.AdaptCityToCityDto(updatedCity));
        }
    }
}
