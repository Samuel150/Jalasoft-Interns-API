using InternsAPI.Controllers;
using Jalasoft.Interns.API.Adapter;
using Jalasoft.Interns.API.Requests.Employees;
using Jalasoft.Interns.Service.Domain.Employees;
using Jalasoft.Interns.Service.Employees;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Jalasoft.Interns.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController(
        ILogger<BooksController> logger,
        IEmployeeService employeeService,
        IEmployeeAdapter employeeAdapter) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees([FromQuery] bool active)
        {
            logger.Log(LogLevel.Information, "Retrieving Employees");
            var employees = employeeService.RetrieveEmployees(active);
            return Ok(employees);
        }


        [HttpPost]
        public IActionResult PostEmployee([FromBody] PostEmpoyeeRequest request)
        {
            logger.Log(LogLevel.Information, "Create Employee");
            var employeeCreated = employeeService.CreateEmployee(employeeAdapter.PostEmployeeRequestToEmployee(request));
            return Created("", employeeAdapter.EmployeeToPostEmployeeResponse(employeeCreated));
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult PatchEmployee(
            [FromBody] JsonPatchDocument<PatchEmployee> patchDocument,
            int id)
        {
            logger.Log(LogLevel.Information, "Patch Employee");
            var employeeCreated = employeeService.PatchEmployee(patchDocument, id);
            return Ok(employeeAdapter.EmployeeToPostEmployeeResponse(employeeCreated));
        }
    }
}
