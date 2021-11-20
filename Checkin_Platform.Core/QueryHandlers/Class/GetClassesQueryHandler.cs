using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Class;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Class
{
    public class GetClassesQueryHandler : IRequestHandler<GetClassesQuery, IEnumerable<GetClassDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetClassesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetClassDto>> Handle(GetClassesQuery request, CancellationToken cancellationToken)
        {
            var classList =  _unitOfWork.ClassRepository.GetClasses();
            var classDtoList = new List<GetClassDto>();
            foreach(var item in classList)
            {
                classDtoList.Add(new GetClassDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Section = item.Section,
                    Teacher = item.Teacher,
                    Year = item.Year
                });
            }
            return classDtoList;
        }
    }
}
