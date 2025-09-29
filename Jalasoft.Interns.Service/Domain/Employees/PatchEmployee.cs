namespace Jalasoft.Interns.Service.Domain.Employees
{
    public class PatchEmployee
    {
        public string FirstName { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

        public Address Address { get; set; } = new Address();
    }

    public class Address
    {
        public string City { get; set; }
    }
}
