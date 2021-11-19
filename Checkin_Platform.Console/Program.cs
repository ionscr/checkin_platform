using Checkin_Platform.Core.CommandHandlers;
using Checkin_Platform.Core.CommandHandlers.User;
using Checkin_Platform.Core.Commands.Class;
using Checkin_Platform.Core.Commands.User;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Class;
using Checkin_Platform.Core.Queries.User;
using Checkin_Platform.Core.QueryHandlers;
using Checkin_Platform.Core.QueryHandlers.User;
using Checkin_Platform.Infrastructure.Data;
using System;
using System.Linq;

namespace Checkin_Platform.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var userDto1 = new UserDto
            {
                FirstName = "first",
                LastName = "user",
                Year = 1,
                Role = "Student",
                Department = "dpasd",
                Group = "aa12",
            };
            var unitOfWork = new UnitOfWork(new AppDbContext());
            var createUserCommand = new CreateUserCommand()
            {
                UserDto = userDto1
            };
            var userCommandHandler = new CreateUserCommandHandler(unitOfWork);
            userCommandHandler.Handle(createUserCommand, new System.Threading.CancellationToken()).Wait();

            var classDto1 = new ClassDto
            {
                Teacher = unitOfWork.UserRepository.GetUsers().FirstOrDefault(),
                Name = "class 1",
                Section = "section 1",
                Year = 3
            };
            var classDto2 = new ClassDto
            {
                Teacher = unitOfWork.UserRepository.GetUsers().FirstOrDefault(),
                Name = "class 2",
                Section = "section 2",
                Year = 1
            };

            var createClassCommand1 = new CreateClassCommand()
            {
                ClassDto = classDto1
            };
            var createClassCommand2 = new CreateClassCommand()
            {
                ClassDto = classDto2
            };
            var classCommandHandler = new CreateClassCommandHandler(unitOfWork);
            //classCommandHandler.Handle(createClassCommand1, new System.Threading.CancellationToken()).Wait();
            //classCommandHandler.Handle(createClassCommand2, new System.Threading.CancellationToken()).Wait();
            var getClassesQuery = new GetClassesQuery();
            var queryHandler = new GetClassesQueryHandler(unitOfWork);
            var classResult = queryHandler.Handle(getClassesQuery, new System.Threading.CancellationToken());
            foreach(var item in classResult.Result.ToList())
            {
                System.Console.WriteLine(item.Name + " " + item.Section + " " + item.Year + " " + item.Teacher.FirstName);
            }
            var deleteClassCommand = new DeleteClassCommand()
            {
                //Id = unitOfWork.ClassRepository.GetClasses().OrderByDescending(c => c.Id).FirstOrDefault().Id
                Id = 200
            };
            var deleteClassHandler = new DeleteClassCommandHandler(unitOfWork);
            deleteClassHandler.Handle(deleteClassCommand, new System.Threading.CancellationToken()).Wait();
            System.Console.WriteLine();
            classResult = queryHandler.Handle(getClassesQuery, new System.Threading.CancellationToken());
            foreach (var item in classResult.Result.ToList())
            {
                System.Console.WriteLine(item.Name + " " + item.Section + " " + item.Year + " " + item.Teacher.FirstName);
            }
        }
    }
}
