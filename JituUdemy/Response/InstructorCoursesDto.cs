namespace JituUdemy.Response
{
    public class InstructorCoursesDto
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<CourseDto> Courses { get; set; }
    }

    public class CourseDto 
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }

        public int PurchasedCount { get; set; }
    }
}
