using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [NotMapped]
    public class ComplaintFormModel
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string complaint {get;set;}
        public bool consent { get; set; }
        public string contact { get; set; }
    }
}