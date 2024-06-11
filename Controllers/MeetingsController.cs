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
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingServices _meetingServices;
        private readonly IMapper _mapper;
        public MeetingsController(IMeetingServices meetingServices, IMapper mapper)
        {
            this._mapper = mapper;
            this._meetingServices = meetingServices;

        }


        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetAllMeetings()
        {
            var meetings = await _meetingServices.GetAllWithMeeting();
            var meetingResources = _mapper.Map<IEnumerable<Meeting>, IEnumerable<MeetingResource>>(meetings);
            return Ok(meetingResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetingsById(int id)
        {
            var meetings = await _meetingServices.GetMeetingById(id);
            var meetingResources = _mapper.Map<Meeting, MeetingResource>(meetings);
            return Ok(meetingResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<MeetingResource>> CreateMeeting([FromBody] SaveMeetingResource saveMeetingResource)
        {
            var validator = new SaveMeetingResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMeetingResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var meetingToCreate = _mapper.Map<SaveMeetingResource, Meeting>(saveMeetingResource);
            var newMeeting = await _meetingServices.CreateMeeting(meetingToCreate);
            var meeting = await _meetingServices.GetMeetingById(newMeeting.ReservationId);
            var meetingResource = _mapper.Map<Meeting, MeetingResource>(meeting);

            return Ok(meetingResource);

        }

        [HttpPut("{id}")]

        public async Task<ActionResult<MeetingResource>> UpdateMeeting(int id, [FromBody] SaveMeetingResource saveMeetingResource)
        {

            var validator = new SaveMeetingResourceValidator();
            var validatorResult = await validator.ValidateAsync(saveMeetingResource);

            var requestIsInvalid = id == 0 || !validatorResult.IsValid;

            if (!requestIsInvalid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var meetingToUpdate = await _meetingServices.GetMeetingById(id);
            if (meetingToUpdate == null)
            {
                return NotFound();
            }

            var meeting = _mapper.Map<SaveMeetingResource, Meeting>(saveMeetingResource);

            await _meetingServices.UpdateMeeting(meetingToUpdate, meeting);

            var updatedMeeting = await _meetingServices.GetMeetingById(id);
            var updatedMeetingResource = _mapper.Map<Meeting, MeetingResource>(updatedMeeting);

            return Ok(updatedMeetingResource);


        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteMeeting(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }

            var meeting = await _meetingServices.GetMeetingById(id);

            if (meeting == null)
            {
                return NotFound();
            }

            await _meetingServices.DeleteMeeting(meeting);
            return NoContent();
        }
    }

}
