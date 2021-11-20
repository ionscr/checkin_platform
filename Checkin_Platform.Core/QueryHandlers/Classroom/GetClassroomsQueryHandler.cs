using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Classroom;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Classroom
{
    public class GetClassroomsQueryHandler: IRequestHandler<GetClassroomsQuery, IEnumerable<GetClassroomDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetClassroomsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetClassroomDto>> Handle(GetClassroomsQuery request, CancellationToken cancellationToken)
        {
            var classroomList = _unitOfWork.ClassroomRepository.GetClassrooms();
            var classroomDtoList = new List<GetClassroomDto>();
            foreach (var item in classroomList)
            {
                classroomDtoList.Add(new GetClassroomDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Capacity = item.Capacity,
                    Location = item.Location
                });
            }
            return classroomDtoList;
        }
    }
}
