using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Class;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Class;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkin_Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMediator _mediator;
        private IMapper _mapper;
        public ClassController(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetClassDto>>> GetClasses() 
        {
            var getClassesQuery = new GetClassesQuery() { };
            var result = await _mediator.Send(getClassesQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreateClass([FromBody] SetClassDto classDto)
        {
            var createClassCommand = new CreateClassCommand() 
            { 
                ClassDto = classDto 
            };
            var result = await _mediator.Send(createClassCommand);
            return Ok(true);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateClass([FromBody] GetClassDto classDto)
        {
            var updateClassCommand = new UpdateClassCommand()
            {
                ClassDto = classDto
            };
            var result = await _mediator.Send(updateClassCommand);
            return Ok(true);
        }
        [Route("{classId}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteClass(int classId)
        {
            var deleteClassCommand = new DeleteClassCommand()
            {
                Id = classId
            };
            var result = await _mediator.Send(deleteClassCommand);
            return Ok(true);
        }
    }
}
