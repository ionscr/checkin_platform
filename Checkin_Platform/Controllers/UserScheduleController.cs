using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.UserSchedule;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.UserSchedule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkin_Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserScheduleController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMediator _mediator;
        public UserScheduleController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserScheduleDto>>> GetUserSchedules()
        {
            var getUserSchedulesQuery = new GetUserSchedulesQuery() { };
            var result = await _mediator.Send(getUserSchedulesQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUserSchedule([FromBody] SetUserScheduleDto userScheduleDto)
        {
            var createUserScheduleCommand = new CreateUserScheduleCommand()
            {
                UserScheduleDto = userScheduleDto
            };
            var result = await _mediator.Send(createUserScheduleCommand);
            return Ok(true);
        }

        [Route("{userScheduleId}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUserSchedule(int userScheduleId)
        {
            var deleteUserScheduleCommand = new DeleteUserScheduleCommand()
            {
                Id = userScheduleId
            };
            var result = await _mediator.Send(deleteUserScheduleCommand);
            return Ok(true);
        }
    }
}
