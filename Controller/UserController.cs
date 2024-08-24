using AutoMapper;
using jobify_Backend.Data;
using jobify_Backend.Dto;
using jobify_Backend.Interfaces;
using jobify_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobify_Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GetUserDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<GetUserDto>>(_userRepository.GetUsers());
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(GetUserDto))]
        [ProducesResponseType(400)]
        public IActionResult GetUserById(int userId)
        {
            var user = _mapper.Map<GetUserDto>(_userRepository.GetUser(userId));    
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GetUserDto))]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] GetUserDto userDto)
        {
            if (userDto == null) return BadRequest(ModelState);
            var user = _userRepository.GetUsers().Where(u => u.UserName.Trim().ToUpper() == userDto.UserName.Trim().ToUpper()).FirstOrDefault();
                        //u.Email.Trim().ToUpper() == userDto.Email.Trim().ToUpper()).FirstOrDefault();
            if(user != null)
            {
                ModelState.AddModelError("", "A user with that name  already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userMap = _mapper.Map<User>(userDto);
            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong.Please Try again later.");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfuly Created a user.");
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int userId)
        {
            if(!_userRepository.UserExists(userId)) return NotFound();
            var user = _userRepository.GetUser(userId);
            if(user == null) return BadRequest(ModelState);
            if (!_userRepository.DeleteUser(user))
            {
                ModelState.AddModelError("", "An error occurred while deleting the user. Please try again later.");
                return StatusCode(500, ModelState);
            }
            return Ok("User Deleted Successfully!");
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int userId, [FromBody] GetUserDto model)
        {
            var user = _userRepository.GetUsers().Where(u => u.UserName.Trim().ToUpper() == model.UserName.Trim().ToUpper()).FirstOrDefault();
                   //u.Email.Trim().ToUpper() == model.Email.Trim().ToUpper()).FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "A user with that name  already exists.");
                return StatusCode(422, ModelState);
            }


            if (model == null) return BadRequest(ModelState);
            if (!_userRepository.UserExists(userId)) return NotFound();
            if(userId != model.UserId) return BadRequest(ModelState);   
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var updatedUser = _mapper.Map<User>(model);
            if (!_userRepository.UpdateUser(updatedUser))
            {
                ModelState.AddModelError("", "An error occurred while updating the user. Please try again later.");
                return StatusCode(500, ModelState);
            }
            return Ok("User Updated Successfully!");
        }

        //[HttpGet("/applied-jobs/${userId}")]
        //[ProducesResponseType(200, Type = typeof(List<Job>))]
        //[ProducesResponseType(400)]
        //public IActionResult GetJobByUserId(int userId)
        //{
        //    if(!_userRepository.UserExists(userId)) return NotFound();
        //    var jobs = _userRepository.GetAppliedJobs(userId);
        //    if (jobs == null) return BadRequest(ModelState);
        //    return Ok(jobs);
        //}
    }
}