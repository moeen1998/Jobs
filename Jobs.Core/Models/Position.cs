using System.ComponentModel.DataAnnotations;

namespace Jobs.Core.Models
{
    public class Position : BaseModel
    {
        public int ID { get; set; }
        
        public string Title { get; set; }

        public string Company { get; set; }
        
        public string Location { get; set; }
        
        public string Description { get; set; }

        public string Requirement { get; set; }

        public float Salary { get; set; }
    }
}
