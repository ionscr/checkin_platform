using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Feature;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Feature;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkin_Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeatureController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMediator _mediator;
        public FeatureController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFeatureDto>>> GetFeatures()
        {
            var getFeaturesQuery = new GetFeaturesQuery() { };
            var result = await _mediator.Send(getFeaturesQuery);
            return Ok(result);
        }

        [Route("{classroomId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFeatureDto>>> GetFeaturesByClassroom(int classroomId)
        {
            var getFeaturesByClassroomQuery = new GetFeaturesByClassroomQuery()
            {
                ClassroomId = classroomId
            };
            var result = await _mediator.Send(getFeaturesByClassroomQuery);
            return Ok(result);
        }
        [Route("other/{classroomId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFeatureDto>>> GetOtherFeaturesByClassroom(int classroomId)
        {
            var getOtherFeaturesByClassroomQuery = new GetOtherFeaturesByClassroomQuery()
            {
                ClassroomId = classroomId
            };
            var result = await _mediator.Send(getOtherFeaturesByClassroomQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreateFeature([FromBody] SetFeatureDto featureDto)
        {
            var createFeatureCommand = new CreateFeatureCommand()
            {
                FeatureDto = featureDto
            };
            var result = await _mediator.Send(createFeatureCommand);
            return Ok(true);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateFeature([FromBody] GetFeatureDto featureDto)
        {
            var updateFeatureCommand = new UpdateFeatureCommand()
            {
                FeatureDto = featureDto
            };
            var result = await _mediator.Send(updateFeatureCommand);
            return Ok(true);
        }

        [Route("{featureId}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteFeature(int featureId)
        {
            var deleteFeatureCommand = new DeleteFeatureCommand()
            {
                Id = featureId
            };
            var result = await _mediator.Send(deleteFeatureCommand);
            return Ok(true);
        }
    }
}
