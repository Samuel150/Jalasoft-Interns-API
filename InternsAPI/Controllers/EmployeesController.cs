using AutoMapper;
using InternsAPI.Controllers;
using Jalasoft.Interns.API.ExceptionHandling;
using Jalasoft.Interns.API.Requests.Employees;
using Jalasoft.Interns.API.Responses.Employees;
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
        IMapper mapper,
        ResponseFilter filter) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees([FromQuery] bool active)
        {
            logger.Log(LogLevel.Information, "Retrieving Employees");
            var employees = employeeService.RetrieveEmployees(active);
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployee(int id)
        {
            return filter.Excecute(() =>
            {
                logger.Log(LogLevel.Information, "Retrieving Employees");
                var employee = employeeService.RetrieveEmployee(id);
                return Ok(employee);
            });
        }


        [HttpPost]
        public IActionResult PostEmployee([FromBody] PostEmpoyeeRequest request)
        {
            return filter.Excecute(() =>
            {
                logger.Log(LogLevel.Information, "Create Employee");
                var employeeCreated = employeeService.CreateEmployee(mapper.Map<Employee>(request));
                return Created("", mapper.Map<PostEmployeeResponse>(employeeCreated));
            });
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult PatchEmployee(
            [FromBody] JsonPatchDocument<PatchEmployee> patchDocument,
            int id)
        {
            return filter.Excecute(() =>
            {
                logger.Log(LogLevel.Information, "Patch Employee");
                var employeeCreated = employeeService.PatchEmployee(patchDocument, id);
                return Ok(mapper.Map<PostEmployeeResponse>(employeeCreated));
            });
        }
    }
}
