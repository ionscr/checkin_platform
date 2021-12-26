using MediatR;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.User
{
    public class GetUsersRolesQuery : IRequest<IEnumerable<string>>
    {
    }
}
