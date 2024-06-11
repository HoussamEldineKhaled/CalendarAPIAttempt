using AutoMapper;
using BookingMeeting.Core.Interfaces;
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
    public class RoomsController : ControllerBase
    {
        private readonly IRoomServices _roomServices;
        private readonly IMapper _mapper;
        public RoomsController(IRoomServices roomServices, IMapper mapper)
        {
            this._mapper = mapper;
            this._roomServices = roomServices;
        }


        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
        {
            var rooms = await _roomServices.GetAllWithRoom();
            var roomResources = _mapper.Map<IEnumerable<Room>, IEnumerable<RoomResource>>(rooms);
            return Ok(roomResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsById(int id)
        {
            var rooms = await _roomServices.GetRoomById(id);
            var roomResources = _mapper.Map<Room, RoomResource>(rooms);
            return Ok(roomResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<RoomResource>> CreateRoom([FromBody] SaveRoomResource saveRoomResource)
        {
            var validator = new SaveRoomResourceValidator();
            var validationResult = await validator.ValidateAsync(saveRoomResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var roomToCreate = _mapper.Map<SaveRoomResource, Room>(saveRoomResource);
            var newRoom = await _roomServices.CreateRoom(roomToCreate);
            var room = await _roomServices.GetRoomById(newRoom.RoomId);
            var roomResource = _mapper.Map<Room, RoomResource>(room);

            return Ok(roomResource);

        }

        [HttpPut("{id}")]

        public async Task<ActionResult<RoomResource>> UpdateRoom(int id, [FromBody] SaveRoomResource saveRoomResource)
        {

            var validator = new SaveRoomResourceValidator();
            var validatorResult = await validator.ValidateAsync(saveRoomResource);

            var requestIsInvalid = id == 0 || !validatorResult.IsValid;

            if (!requestIsInvalid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var roomToUpdate = await _roomServices.GetRoomById(id);
            if (roomToUpdate == null)
            {
                return NotFound();
            }

            var room = _mapper.Map<SaveRoomResource, Room>(saveRoomResource);

            await _roomServices.UpdateRoom(roomToUpdate, room);

            var updatedRoom = await _roomServices.GetRoomById(id);
            var updatedRoomResource = _mapper.Map<Room, RoomResource>(updatedRoom);

            return Ok(updatedRoomResource);


        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteRoom(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }

            var room = await _roomServices.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            await _roomServices.DeleteRoom(room);
            return NoContent();
        }
    }
}
