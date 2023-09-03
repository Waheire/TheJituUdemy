using JituUdemy.Data;
using JituUdemy.Entities;
using JituUdemy.Response;
using JituUdemy.Services.IServiecs;
using Microsoft.EntityFrameworkCore;

namespace JituUdemy.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly JituUdemyDbContext _context;
        public InstructorService(JituUdemyDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddInstructorAsync(Instructor instructor)
        {
           _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return "Instructor Added successfully";
        }

        public async Task<string> DeleteInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return "Instructor Deleted successfully";
        }

        public async Task<IEnumerable<InstructorCoursesDto>> GetAllInstructorsAsync()
        {
            return await _context.Instructors
                .Select(i => new InstructorCoursesDto()
            {
                InstructorId = i.InstructorId,
                Name = i.Name,
                Email = i.Email,
                Courses = i.Courses.Select(c => new CourseDto()
                {
                    CourseId = c.CourseId,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    PurchasedCount = c.Users.Count()
                }).ToList(),
            }).ToListAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(Guid id)
        {
            return await _context.Instructors.Where(x => x.InstructorId == id).FirstOrDefaultAsync();
        }

        public async Task<InstructorCoursesDto> GetUserandCoursesIdAsync(Guid userId)
        {
             return await _context.Instructors.
             Where(x => x.InstructorId == userId).
             Select(i => new InstructorCoursesDto()
             {
                 InstructorId = i.InstructorId,
                 Name = i.Name,
                 Email = i.Email,
                 Courses = i.Courses.Select(c => new CourseDto()
                 {
                     CourseId = c.CourseId,
                     Name = c.Name,
                     Description = c.Description,
                     Price = c.Price,
                     PurchasedCount = c.Users.Count()
                 }).ToList(),
             }).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return "Instructor Updated successfully";
        }
    }
}
