using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Class;
using Checkin_Platform.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers
{
    public class CreateClassCommandHandler: IRequestHandler<CreateClassCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public CreateClassCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.Class.Add(new Class
            {
                Name = request.ClassDto.Name,
                Section = request.ClassDto.Section,
                Teacher = request.ClassDto.Teacher,
                Year = request.ClassDto.Year
            });
            return true;
        }
    }
}
