using JituUdemy.Entities;
using JituUdemy.Request;

namespace JituUdemy.Services.IServiecs
{
    public interface IInstructorService
    {
        //Adding a Instructor
        Task<string> AddInstructorAsync(Instructor instructor);
        //update Instructor 
        Task<string> UpdateInstructorAsync(Instructor instructor);
        //Delete a Instructor
        Task<string> DeleteInstructorAsync(Instructor instructor);
        //Get all Instructor
        Task<IEnumerable<Instructor>> GetAllInstructorsAsync();
        //Get one Instructor
        Task<Instructor> GetInstructorByIdAsync(Guid id);
    }
}
