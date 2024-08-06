namespace Clinic.Models.Patient
{
    public class PatientRequest
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
    }
}
