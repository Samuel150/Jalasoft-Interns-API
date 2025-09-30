namespace Jalasoft.Interns.Service.Exceptions
{
    public class EmployeeNotFoundException : InternsException
    {
        public EmployeeNotFoundException(int employeeId) 
            : base($"Employee with id: {employeeId}, not found")
        {
        }
    }
}
