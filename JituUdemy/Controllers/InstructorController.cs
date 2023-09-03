using AutoMapper;
using JituUdemy.Entities;
using JituUdemy.Request;
using JituUdemy.Response;
using JituUdemy.Services.IServiecs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JituUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;

        public InstructorController(IInstructorService service, IMapper mapper)
        {
            _mapper = mapper;
            _instructorService = service;
        }

        [HttpPost]
        public async Task<ActionResult<UserSuccess>> AddInstructor(AddUser newInstructor)
        {
            //mapping 
            var instructor = _mapper.Map<Instructor>(newInstructor);
            var res = await _instructorService.AddInstructorAsync(instructor);
            return CreatedAtAction(nameof(AddInstructor), new UserSuccess(201, res));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorCoursesDto>>> GetAllInstructors() 
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorCoursesDto>> GetInstructor(Guid id)
        {
            var instructor = await _instructorService.GetUserandCoursesIdAsync(id);
            if (instructor == null) 
            {
                return NotFound(new UserSuccess(404, "Instructor not Found"));
            }
            return Ok(instructor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InstructorResponse>> UpdateInstructor(Guid id, AddUser updatedInstructor)
        {
            var response = await _instructorService.GetInstructorByIdAsync(id);
            if (response == null)
            {
                return NotFound(new UserSuccess(404, "Instructor not Found"));
            }
            //update 
            var updated = _mapper.Map(updatedInstructor, response);
            var res = await _instructorService.UpdateInstructorAsync(updated);
            return Ok(new UserSuccess(204, res));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InstructorResponse>> DeleteInstructor(Guid id)
        {
            var response = await _instructorService.GetInstructorByIdAsync(id);
            if (response == null)
            {
                return NotFound(new UserSuccess(404, "Instructor not Found"));
            }
            //update 
            
            var res = await _instructorService.DeleteInstructorAsync(response);
            return Ok(new UserSuccess(204, res));
        }
    }
}
