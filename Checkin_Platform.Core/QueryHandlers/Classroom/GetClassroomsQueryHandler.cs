using AutoMapper;
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
        private IMapper _mapper;
        public GetClassroomsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetClassroomDto>> Handle(GetClassroomsQuery request, CancellationToken cancellationToken)
        {
            var classroomList = _unitOfWork.ClassroomRepository.GetClassrooms();
            var classroomDtoList = _mapper.Map<IEnumerable<Domain.Classroom>, IEnumerable<GetClassroomDto>>(classroomList);
            return classroomDtoList;
        }
    }
}
