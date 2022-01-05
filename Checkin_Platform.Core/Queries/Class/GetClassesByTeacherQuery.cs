using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Queries.Class
{
    public class GetClassesByTeacherQuery : IRequest<IEnumerable<GetClassDto>>
    {
        public int TeacherId { get; set; }
    }
}
