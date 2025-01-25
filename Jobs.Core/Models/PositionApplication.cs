using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.Core.Models
{
    public class PositionApplication : BaseModel
    {
        public int ID { get; set; }

        public string ApplicantName{ get; set; }
        
        public string ApplicantEmail{ get; set; }

        public string ClientFileName{ get; set; }
        
        public string DbFilename{ get; set; }

        [ForeignKey("Position")]
        public int PositionID { get; set; }

        public Position Position { get; set; }

    }
}
