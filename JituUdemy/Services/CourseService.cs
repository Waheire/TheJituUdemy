using JituUdemy.Data;
using JituUdemy.Entities;
using JituUdemy.Response;
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

        private async Task<IEnumerable<Course>> getAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<(IEnumerable<Course>, paginationMetaData)> 
            GetAllCoursesAsync(string? name, int? price, string? instructor, int pageSize, int pageNumber)
        {
            if (string.IsNullOrWhiteSpace(name) && price == 0 && string.IsNullOrWhiteSpace(instructor)) 
            {
                //no serach string or filter
                var CourseList = await getAllCourses();
                var count = CourseList.Count();
                CourseList = CourseList.Skip(pageSize *(pageNumber-1)).Take(pageSize);
                var paginationMetaData = new paginationMetaData(pageSize, pageNumber, count);
                return (CourseList, paginationMetaData);
            }

            //Deferred execution
            //build up the query
            var query = _context.Courses.AsQueryable<Course>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.Name.ToLower().Contains(name.ToLower()) || c.Description.ToLower().Contains(name.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(instructor))
            {
                query = query.Where(c => c.Instructor.Name.ToLower().Contains(instructor.ToLower()));
            }
            if (price > 0) 
            {
                query = query.Where(c => c.Price <= price);
            }

            //sort the data
            query = query.OrderBy(c => c.Price);
            //get total number of rows
            var filteredCount  = query.Count();
            //pagination
            query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            var paginationMetaData1 = new paginationMetaData(pageSize, pageNumber, filteredCount);
            //execute it
            return (await query.ToListAsync(), paginationMetaData1);
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
