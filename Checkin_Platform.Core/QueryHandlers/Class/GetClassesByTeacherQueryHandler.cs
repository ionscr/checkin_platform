using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Class;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Class
{
    class GetClassesByTeacherQueryHandler : IRequestHandler<GetClassesByTeacherQuery, IEnumerable<GetClassDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetClassesByTeacherQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetClassDto>> Handle(GetClassesByTeacherQuery request, CancellationToken cancellationToken)
        {
            var classList = _unitOfWork.ClassRepository.GetClassesByTeacher(request.TeacherId);
            var classDtoList = _mapper.Map<IEnumerable<Domain.Class>, IEnumerable<GetClassDto>>(classList);
            return classDtoList;
        }
    }
}
