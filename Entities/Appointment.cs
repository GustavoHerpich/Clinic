namespace Clinic.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public int IdUser { get; set; } //quem criou a consulta
        public DateTime AppointmentDate { get; set; }
    }
}
