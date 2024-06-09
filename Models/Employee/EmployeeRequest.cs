using Clinic.Models.Enums;

namespace Clinic.Models.Employee
{
    public class EmployeeRequest
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required Roles Role { get; set; }
    }
}
