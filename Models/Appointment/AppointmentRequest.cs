namespace Clinic.Models.Appointment
{
    public class AppointmentRequest
    {
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public int IdUser { get; set; } 
        public DateTime AppointmentDate { get; set; }
    }
}
