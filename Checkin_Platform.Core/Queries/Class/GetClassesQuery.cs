using Checkin_Platform.Core.Dto;
using MediatR;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.Class
{
    public class GetClassesQuery: IRequest<IEnumerable<ClassDto>>
    {

    }
}
