using Jobs.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Jobs.Core.DTOs
{
    public class PositionDTO
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
