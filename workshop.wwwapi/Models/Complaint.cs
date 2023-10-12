namespace workshop.wwwapi.Models
{
    public class Complaint
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string complaint { get; set; }
        public bool consent { get; set; }
        public string contact { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

    }
}
