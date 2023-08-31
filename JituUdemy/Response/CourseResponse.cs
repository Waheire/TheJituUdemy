namespace JituUdemy.Response
{
    public class CourseResponse
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public Guid InstructorId { get; set; } = default!;
    }
}
