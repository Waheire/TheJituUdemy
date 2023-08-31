using JituUdemy.Data;
using JituUdemy.Entities;
using JituUdemy.Request;
using JituUdemy.Services.IServiecs;
using Microsoft.EntityFrameworkCore;

namespace JituUdemy.Services
{
    public class UserService : IUserService
    {
        private readonly JituUdemyDbContext _context;
        public UserService(JituUdemyDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User Created successfully";
        }

        public Task<string> BuyCourse(BuyCourse buyCourse)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return "User Deleted successfully";
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
           return await  _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
  
        }

        public async Task<string> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return "User Updated successfully";
        }
    }
}
