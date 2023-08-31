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
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllInstructors() 
        {
            var response = await _instructorService.GetAllInstructorsAsync();
            var instructors = _mapper.Map<IEnumerable<UserResponse>>(response);
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetInstructor(Guid id)
        {
            var response = await _instructorService.GetInstructorByIdAsync(id);
            if (response == null) 
            {
                return NotFound(new UserSuccess(404, "Instructor not Found"));
            }
            var instructor = _mapper.Map<UserResponse>(response);
            return Ok(instructor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> UpdateInstructor(Guid id, AddUser updatedInstructor)
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
        public async Task<ActionResult<UserResponse>> DeleteInstructor(Guid id)
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
