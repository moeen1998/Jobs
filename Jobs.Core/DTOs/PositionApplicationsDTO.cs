using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Jobs.Core.DTOs
{
    public class PositionApplicationsDTO
    {
        [Required]
        public string CV { get; set; }
        [Required]
        public string ApplicantName { get; set; }

        [EmailAddress]
        public string ApplicantEmail { get; set; }
        [Required]
        public string ClientFileName { get; set; }

        public string DbFilename { get; set; }
        [Required]
        public int PositionID { get; set; }

    }
}
