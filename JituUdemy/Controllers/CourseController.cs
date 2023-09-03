using AutoMapper;
using JituUdemy.Entities;
using JituUdemy.Request;
using JituUdemy.Response;
using JituUdemy.Services.IServiecs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JituUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 20;

        public CourseController(ICourseService service, IMapper mapper)
        {
            _courseService = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserSuccess>> AddCourse(AddCourse newCourse)
        {
            try
            {
                var course = _mapper.Map<Course>(newCourse);
                var res = await _courseService.AddCourseAsync(course);
                return CreatedAtAction(nameof(AddCourse), new UserSuccess(201, res));

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<(IEnumerable<CourseResponse>, paginationMetaData)>> 
            GetAllCourses([FromQuery] string? name,  [FromQuery] string? instructor, [FromQuery] int? price = 0, int pageSize = 1, int pageNumber=1)
        {
            //serach/ filter feature
            if (pageSize > MaxPageSize) 
            {
                pageSize = MaxPageSize;
            }
            if(price< 0){ price = 0;}
            var (response, paginationMetaData) = await _courseService.GetAllCoursesAsync(name, price, instructor, pageSize, pageNumber);
            var courses = _mapper.Map<IEnumerable<CourseResponse>>(response);

            //set it to the Headers (communicate data to frontend)
            Response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationMetaData));
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResponse>> GetCourse(Guid id)
        {
            var response = await _courseService.GetCourseByIdAsync(id);
            if (response == null)
            {
                return BadRequest(new UserSuccess(404, "Course Does not Exist."));
            }
            var course = _mapper.Map<CourseResponse>(response);
            return Ok(course);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UserSuccess>> UpdateCourse(Guid id, UpdateCourse UpdatedCourse)
        {
            var response = await _courseService.GetCourseByIdAsync(id);
            if (response == null)
            {
                return NotFound(new UserSuccess(404, "Course Does not Exist."));
            }
            //update 
            var updated = _mapper.Map(UpdatedCourse, response);
            var res = await _courseService.UpdateCourseAsync(updated);
            return Ok(new UserSuccess(204, res));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserSuccess>> DeleteCourse(Guid id)
        {
            var response = await _courseService.GetCourseByIdAsync(id);
            if (response == null)
            {
                return BadRequest(new UserSuccess(404, "Course Does not Exist."));
            }
            //Delete
            var res = await _courseService.DeleteCourseAsync(response);
            return Ok(new UserSuccess(204, res));
        }
    }
}
