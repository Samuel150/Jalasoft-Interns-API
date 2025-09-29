namespace Jalasoft.Interns.Service.Domain.Employees
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; }= string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Active { get; set; }

        public Address Address { get; set; }
    }
}
