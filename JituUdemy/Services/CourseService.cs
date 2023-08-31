using JituUdemy.Data;
using JituUdemy.Entities;
using JituUdemy.Services.IServiecs;
using Microsoft.EntityFrameworkCore;

namespace JituUdemy.Services
{
    public class CourseService : ICourseService
    {
        private readonly JituUdemyDbContext _context;
        public CourseService(JituUdemyDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return "Courses added successfully";
        }

        public async Task<string> DeleteCourseAsync(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return "Courses Deleted successfully";
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(Guid courseId)
        {
            return await _context.Courses.Where(x => x.CourseId == courseId).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return "Courses Updated successfully";
        }
    }
}
