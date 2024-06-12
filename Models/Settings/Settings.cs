using System.ComponentModel.DataAnnotations;

namespace Clinic.Models.Settings
{
    public class Settings
    {
        public const string SectionName = "Settings";

        [Required]
        public string? Secret { get; set; }
    }
}
