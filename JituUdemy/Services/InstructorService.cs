using JituUdemy.Data;
using JituUdemy.Entities;
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

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
           return await _context.Instructors.ToListAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(Guid id)
        {
            return await _context.Instructors.Where(x => x.InstructorId == id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return "Instructor Updated successfully";
        }
    }
}
