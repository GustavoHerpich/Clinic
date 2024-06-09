namespace Clinic.Models.Login
{
    public class RecoverPasswordRequest
    {
        public required string UserName { get; set; }
        public required string NewPassword { get; set; }
    }
}
