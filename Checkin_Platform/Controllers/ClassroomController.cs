using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Classroom;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Classroom;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkin_Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMediator _mediator;
        public ClassroomController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetClassroomDto>>> GetClassrooms()
        {
            var getClassroomsQuery = new GetClassroomsQuery() { };
            var result = await _mediator.Send(getClassroomsQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateClassroom([FromBody] SetClassroomDto classroomDto)
        {
            var createClassroomCommand = new CreateClassroomCommand()
            {
                ClassroomDto = classroomDto
            };
            var result = await _mediator.Send(createClassroomCommand);
            return Ok(true);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateClassroom([FromBody] GetClassroomDto classroomDto)
        {
            var updateClassroomCommand = new UpdateClassroomCommand()
            {
                ClassroomDto = classroomDto
            };
            var result = await _mediator.Send(updateClassroomCommand);
            return Ok(true);
        }

        [Route("{classroomId}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteClassroom(int classroomId)
        {
            var deleteClassroomCommand = new DeleteClassroomCommand()
            {
                Id = classroomId
            };
            var result = await _mediator.Send(deleteClassroomCommand);
            return Ok(true);
        }
    }
}
