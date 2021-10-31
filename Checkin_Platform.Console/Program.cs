using Checkin_Platform.Core.CommandHandlers.User;
using Checkin_Platform.Core.Commands.User;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Infrastructure.Data;
using System;
using System.Linq;

namespace Checkin_Platform.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var userDto = new UserDto
            {
                FirstName = "asd",
                LastName = "wqe",
                Year = 1,
                Role = 1,
                Department = "dpasd",
                Group = "aa12",
            };
            var unitOfWork = new AppDbContext();
            var createUserCommand = new CreateUserCommand()
            {
                UserDto = userDto
            };
            var commandHandler = new CreateUserCommandHandler(unitOfWork);
            commandHandler.Handle(createUserCommand, new System.Threading.CancellationToken()).Wait();
            var result = unitOfWork.User.ToList();
        }
    }
}
