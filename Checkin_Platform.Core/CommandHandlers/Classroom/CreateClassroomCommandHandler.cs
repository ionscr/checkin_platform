using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Classroom;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Classroom
{
    public class CreateClassroomCommandHandler: IRequestHandler<CreateClassroomCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public CreateClassroomCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.Classroom.Add(new Domain.Classroom
            {
                Name = request.ClassroomDto.Name,
                Capacity = request.ClassroomDto.Capacity,
                Location = request.ClassroomDto.Location,
                ClassroomFeatures = request.ClassroomDto.ClassroomFeatures
            });
            return true;
        }
    }
}
