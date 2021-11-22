using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Class;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers
{
    public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateClassCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.ClassRepository.GetClassById(request.ClassDto.Id);
            item.Name = request.ClassDto.Name;
            item.Section = request.ClassDto.Section;
            item.Teacher = request.ClassDto.Teacher;
            item.Year = request.ClassDto.Year;
            _unitOfWork.ClassRepository.UpdateClass(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
