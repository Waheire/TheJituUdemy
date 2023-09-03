using JituUdemy.Entities;
using JituUdemy.Response;

namespace JituUdemy.Services.IServiecs
{
    public interface ICourseService
    {
        Task<string> AddCourseAsync(Course cousrse);
        Task<string> DeleteCourseAsync(Course cousrse);
        Task<string> UpdateCourseAsync(Course course);

        Task<(IEnumerable<Course>, paginationMetaData)> 
            GetAllCoursesAsync(string? name, int? price, string? instructor, int pageSize, int pageNumber);
        Task<Course> GetCourseByIdAsync(Guid courseId);

    }
}
