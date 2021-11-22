using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Classroom;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Classroom
{
    public class UpdateClassroomCommandHandler : IRequestHandler<UpdateClassroomCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateClassroomCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.ClassroomRepository.GetClassroomById(request.classroomDto.Id);
            item.Name = request.classroomDto.Name;
            item.Location = request.classroomDto.Location;
            item.Capacity = request.classroomDto.Capacity;
            _unitOfWork.ClassroomRepository.UpdateClassroom(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
