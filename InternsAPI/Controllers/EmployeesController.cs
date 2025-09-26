using InternsAPI.Controllers;
using Jalasoft.Interns.Service.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Jalasoft.Interns.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController(ILogger<BooksController> logger, IEmployeeService employeeService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees([FromQuery] bool active)
        {
            logger.Log(LogLevel.Information, "Retrieving Employees");
            var employees = employeeService.RetrieveEmployees(active);
            return Ok(employees);
        }
    }
}
