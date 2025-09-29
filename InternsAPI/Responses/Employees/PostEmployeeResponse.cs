using Jalasoft.Interns.Service.Domain.Employees;

namespace Jalasoft.Interns.API.Responses.Employees
{
    public class PostEmployeeResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }


        public string Email { get; set; }

        public bool Active { get; set; }
        public Address Address { get; set; }
    }
}
