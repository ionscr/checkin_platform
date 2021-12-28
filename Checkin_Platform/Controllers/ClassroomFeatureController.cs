using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.ClassroomFeature;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.ClassroomFeature;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkin_Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomFeatureController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMediator _mediator;
        public ClassroomFeatureController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetClassroomFeatureDto>>> GetClassroomFeatures()
        {
            var getClassroomFeaturesQuery = new GetClassroomFeaturesQuery() { };
            var result = await _mediator.Send(getClassroomFeaturesQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateClassroomFeature([FromBody] SetClassroomFeatureDto classroomFeatureDto)
        {
            var createClassroomFeatureCommand = new CreateClassroomFeatureCommand()
            {
                ClassroomFeatureDto = classroomFeatureDto
            };
            var result = await _mediator.Send(createClassroomFeatureCommand);
            return Ok(true);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteClassroomFeature([FromBody] SetClassroomFeatureDto classroomFeatureDto)
        {
            var deleteClassroomFeatureCommand = new DeleteClassroomFeatureCommand()
            {
                FeatureId = classroomFeatureDto.FeatureId,
                ClassroomId = classroomFeatureDto.ClassroomId
            };
            var result = await _mediator.Send(deleteClassroomFeatureCommand);
            return Ok(true);
        }
    }
}
