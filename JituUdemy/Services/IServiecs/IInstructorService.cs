using JituUdemy.Entities;
using JituUdemy.Request;
using JituUdemy.Response;

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
        Task<IEnumerable<InstructorCoursesDto>> GetAllInstructorsAsync();
        //Get one Instructor
        Task<Instructor> GetInstructorByIdAsync(Guid id);

        Task<InstructorCoursesDto> GetUserandCoursesIdAsync(Guid userId);
    }
}
