using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.User;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkin_Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMediator _mediator;
        public UserController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsers()
        {
            var getUsersQuery = new GetUsersQuery() { };
            var result = await _mediator.Send(getUsersQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("role/{role}")]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsersByRole(string role)
        {
            var getUsersByRoleQuery = new GetUsersByRoleQuery() {
            role = role
            };
            var result = await _mediator.Send(getUsersByRoleQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("roles")]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsersRoles()
        {
            var getUsersRolesQuery = new GetUsersRolesQuery() { };
            var result = await _mediator.Send(getUsersRolesQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser([FromBody] SetUserDto userDto)
        {
            var createUserCommand = new CreateUserCommand()
            {
                UserDto = userDto
            };
            var result = await _mediator.Send(createUserCommand);
            return Ok(true);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateUser([FromBody] GetUserDto userDto)
        {
            var updateUserCommand = new UpdateUserCommand()
            {
                UserDto = userDto
            };
            var result = await _mediator.Send(updateUserCommand);
            return Ok(true);
        }

        [Route("{userId}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUser(int userId)
        {
            var deleteUserCommand = new DeleteUserCommand()
            {
                Id = userId
            };
            var result = await _mediator.Send(deleteUserCommand);
            return Ok(true);
        }
    }
}
