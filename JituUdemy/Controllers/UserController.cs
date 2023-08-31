using AutoMapper;
using JituUdemy.Entities;
using JituUdemy.Request;
using JituUdemy.Response;
using JituUdemy.Services.IServiecs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JituUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUserService service, IMapper mapper)
        {
            _mapper = mapper;
            _userService = service;
        }

        [HttpPost]
        public async Task<ActionResult<UserSuccess>> AddUser(AddUser newUser)
        {
            var user = _mapper.Map<User>(newUser);
            var res = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(AddUser),new UserSuccess(201, res));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers() 
        {
            var response = await _userService.GetAllUsersAsync();
            var users = _mapper.Map<IEnumerable<UserResponse>>(response);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(Guid id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            var user = _mapper.Map<UserResponse>(response);
            return Ok(user);
        }
    }
}
