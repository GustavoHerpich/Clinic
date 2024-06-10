namespace Clinic.Models.Patient
{
    public class UpdatePatientRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
    }
}
