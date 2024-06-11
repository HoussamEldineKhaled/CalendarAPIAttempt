using AutoMapper;
using BookingMeeting.Models;
using BookingMeeting.Resources;
using BookingMeeting.Services;
using BookingMeeting.Services.Interfaces;
using BookingMeeting.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BookingMeeting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserController : ControllerBase
    {
        private readonly ISystemUserServices _userServices;
        private readonly IMapper _mapper;
        public SystemUserController(ISystemUserServices userServices, IMapper mapper)
        {
            this._mapper = mapper;
            this._userServices = userServices;
        }


        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<SystemUser>>> GetAllUsers()
        {
            var users = await _userServices.GetAllWithUser();
            var userResources = _mapper.Map<IEnumerable<SystemUser>, IEnumerable<SystemUserResources>>(users);
            return Ok(userResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SystemUser>>> GetUsersById(int id)
        {
            var users = await _userServices.GetUserById(id);
            var userResources = _mapper.Map<SystemUser, SystemUserResources>(users);
            return Ok(userResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<SystemUserResources>> CreateUser([FromBody] SaveSystemUserResource saveUserResource)
        {
            var validator = new SaveSystemUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var userToCreate = _mapper.Map<SaveSystemUserResource, SystemUser>(saveUserResource);
            var newUser = await _userServices.CreateUser(userToCreate);
            var user = await _userServices.GetUserById(newUser.Id);
            var userResource = _mapper.Map<SystemUser, SystemUserResources>(user);

            return Ok(userResource);



        }

        [HttpPut("{id}")]

        public async Task<ActionResult<SystemUserResources>> UpdateUser(int id, [FromBody] SaveSystemUserResource saveUserResource)
        {

            var validator = new SaveSystemUserResourceValidator();
            var validatorResult = await validator.ValidateAsync(saveUserResource);

            var requestIsInvalid = id == 0 || !validatorResult.IsValid;

            if (!requestIsInvalid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var userToUpdate = await _userServices.GetUserById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }

            var user = _mapper.Map<SaveSystemUserResource, SystemUser>(saveUserResource);

            await _userServices.UpdateUser(userToUpdate, user);

            var updatedUser = await _userServices.GetUserById(id);
            var updatedUserResource = _mapper.Map<SystemUser, SystemUserResources>(updatedUser);

            return Ok(updatedUserResource);


        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }

            var user = await _userServices.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userServices.DeleteUser(user);
            return NoContent();
        }
    }
}
