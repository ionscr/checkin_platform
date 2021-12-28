using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Schedule;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Dto.Schedule;
using Checkin_Platform.Core.Queries.Schedule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkin_Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMediator _mediator;
        public ScheduleController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetScheduleDto>>> GetSchedules()
        {
            var getSchedulesQuery = new GetSchedulesQuery() { };
            var result = await _mediator.Send(getSchedulesQuery);
            return Ok(result);
        }

        [Route("date/{dateTime}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetScheduleDto>>> GetSchedulesByDate(DateTime dateTime)
        {
            var getSchedulesByDateQuery = new GetSchedulesByDateQuery()
            {
                DateTime = dateTime
            };
            var result = await _mediator.Send(getSchedulesByDateQuery);
            return Ok(result);
        }
        [Route("week/{dateTime}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetGroupScheduleDto>>> GetSchedulesByWeek(DateTime dateTime)
        {
            var getSchedulesByWeekQuery = new GetSchedulesByWeekQuery()
            {
                StartDate = dateTime
            };
            var result = await _mediator.Send(getSchedulesByWeekQuery);
            return Ok(result);
        }

        [Route("teacher/{teacherId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetScheduleDto>>> GetSchedulesByTeacher(int teacherId)
        {
            var getSchedulesByTeacherQuery = new GetSchedulesByTeacherQuery()
            {
                TeacherId = teacherId
            };
            var result = await _mediator.Send(getSchedulesByTeacherQuery);
            return Ok(result);
        }
        [Route("user/{userId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetScheduleDto>>> GetSchedulesByUserReservations(int userId)
        {
            var getSchedulesByUserReservationsQuery = new GetSchedulesByUserReservationsQuery()
            {
                UserId = userId
            };
            var result = await _mediator.Send(getSchedulesByUserReservationsQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateSchedule([FromBody] SetScheduleDto scheduleDto)
        {
            var createScheduleCommand = new CreateScheduleCommand()
            {
                ScheduleDto = scheduleDto
            };
            var result = await _mediator.Send(createScheduleCommand);
            return Ok(true);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateSchedule([FromBody] GetScheduleDto scheduleDto)
        {
            var updateScheduleCommand = new UpdateScheduleCommand()
            {
                ScheduleDto = scheduleDto
            };
            var result = await _mediator.Send(updateScheduleCommand);
            return Ok(true);
        }

        [Route("{scheduleId}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteSchedule(int scheduleId)
        {
            var deleteScheduleCommand = new DeleteScheduleCommand()
            {
                Id = scheduleId
            };
            var result = await _mediator.Send(deleteScheduleCommand);
            return Ok(true);
        }
    }
}
