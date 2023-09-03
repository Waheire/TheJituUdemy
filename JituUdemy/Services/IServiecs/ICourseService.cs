using JituUdemy.Entities;

namespace JituUdemy.Services.IServiecs
{
    public interface ICourseService
    {
        Task<string> AddCourseAsync(Course cousrse);
        Task<string> DeleteCourseAsync(Course cousrse);
        Task<string> UpdateCourseAsync(Course course);

        Task<IEnumerable<Course>> GetAllCoursesAsync(string? name, int price, string instructor);
        Task<Course> GetCourseByIdAsync(Guid courseId);

    }
}
