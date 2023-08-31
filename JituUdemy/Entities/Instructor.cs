using System.ComponentModel.DataAnnotations;

namespace JituUdemy.Entities
{
    public class Instructor
    {
        [Key]
        public Guid InstructorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Course> Courses  { get; set; } = new List<Course>();
    }
}
