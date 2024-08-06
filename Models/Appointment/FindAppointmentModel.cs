namespace Clinic.Models.Appointment
{
    public class FindAppointmentModel
    {
        public int Id { get; set; }
        public Entities.Doctor Doctor { get; set; }
        public Entities.Patient Patient { get; set; }
        public string Employee { get; set; } 
        public DateTime AppointmentDate { get; set; }
    }
}
