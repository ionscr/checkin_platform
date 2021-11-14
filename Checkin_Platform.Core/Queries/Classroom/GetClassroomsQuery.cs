using Checkin_Platform.Core.Dto;
using MediatR;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.Classroom
{
    public class GetClassroomsQuery: IRequest<IEnumerable<ClassroomDto>>
    {
    }
}
