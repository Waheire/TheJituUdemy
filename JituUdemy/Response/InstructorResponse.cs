using JituUdemy.Entities;

namespace JituUdemy.Response
{
    public class InstructorResponse
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
