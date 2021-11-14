using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Classroom;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Classroom
{
    class GetClassroomsQueryHandler: IRequestHandler<GetClassroomsQuery, IEnumerable<ClassroomDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetClassroomsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClassroomDto>> Handle(GetClassroomsQuery request, CancellationToken cancellationToken)
        {
            var classroomList = _unitOfWork.Classroom.ToList();
            var classroomDtoList = new List<ClassroomDto>();
            foreach (var item in classroomList)
            {
                classroomDtoList.Add(new ClassroomDto
                {
                    Name = item.Name,
                    Capacity = item.Capacity,
                    ClassroomFeatures = item.ClassroomFeatures,
                    Location = item.Location
                });
            }
            return classroomDtoList;
        }
    }
}
