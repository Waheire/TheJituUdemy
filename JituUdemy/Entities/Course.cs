using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JituUdemy.Entities
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }

        [ForeignKey("InstructorId")]
        public Instructor Instructor { get; set; } = default!;
        public Guid InstructorId { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
