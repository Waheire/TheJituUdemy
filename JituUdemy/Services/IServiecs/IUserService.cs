using JituUdemy.Entities;
using JituUdemy.Request;

namespace JituUdemy.Services.IServiecs
{
    public interface IUserService
    {
        // interfaces don't provide implementation
        //shape - skeleton
        
        //Adding a user
        Task<string> AddUserAsync(User user);
        //update user 
        Task<string> UpdateUserAsync(User user);
        //Delete a user
        Task<string> DeleteUserAsync(User user);
        //Get all users
        Task<IEnumerable<User>> GetAllUsersAsync();
        //Get one user
        Task<User> GetUserByIdAsync(Guid id);
        //buy a course
        Task<string> BuyCourse(BuyCourse buyCourse);
    }
}
