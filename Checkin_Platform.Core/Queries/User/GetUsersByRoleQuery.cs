using Checkin_Platform.Core.Dto;
using MediatR;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.User
{
    public class GetUsersByRoleQuery : IRequest<IEnumerable<GetUserDto>>
    {
        public string role { get; set; }
    }
}
