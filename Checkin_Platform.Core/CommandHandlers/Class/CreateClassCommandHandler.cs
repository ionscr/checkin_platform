using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Class;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Class
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
            _unitOfWork.Class.Add(new Domain.Class
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
