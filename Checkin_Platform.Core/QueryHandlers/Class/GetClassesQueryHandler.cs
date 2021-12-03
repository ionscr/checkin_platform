using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Class;
using Checkin_Platform.Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Class
{
    public class GetClassesQueryHandler : IRequestHandler<GetClassesQuery, IEnumerable<GetClassDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetClassesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetClassDto>> Handle(GetClassesQuery request, CancellationToken cancellationToken)
        {
            var classList =  _unitOfWork.ClassRepository.GetClasses();
            var classDtoList = _mapper.Map<IEnumerable<Domain.Class>, IEnumerable<GetClassDto>>(classList);
            return classDtoList;
        }
    }
}
