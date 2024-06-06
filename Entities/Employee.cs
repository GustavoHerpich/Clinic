using Clinic.Models.Enums;

namespace Clinic.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required Roles Role { get; set; }
    }
}
