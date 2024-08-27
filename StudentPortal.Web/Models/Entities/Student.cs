namespace StudentPortal.Web.Models.Entities
{
    public class Student
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Subcribed { get; set; }
    }
}
