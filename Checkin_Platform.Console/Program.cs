using AutoMapper;
using Checkin_Platform.Core.CommandHandlers;
using Checkin_Platform.Core.CommandHandlers.Classroom;
using Checkin_Platform.Core.CommandHandlers.ClassroomFeature;
using Checkin_Platform.Core.CommandHandlers.Feature;
using Checkin_Platform.Core.CommandHandlers.Schedule;
using Checkin_Platform.Core.CommandHandlers.User;
using Checkin_Platform.Core.CommandHandlers.UserSchedule;
using Checkin_Platform.Core.Commands.Class;
using Checkin_Platform.Core.Commands.Classroom;
using Checkin_Platform.Core.Commands.ClassroomFeature;
using Checkin_Platform.Core.Commands.Feature;
using Checkin_Platform.Core.Commands.Schedule;
using Checkin_Platform.Core.Commands.User;
using Checkin_Platform.Core.Commands.UserSchedule;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Class;
using Checkin_Platform.Core.Queries.Classroom;
using Checkin_Platform.Core.Queries.ClassroomFeature;
using Checkin_Platform.Core.Queries.Feature;
using Checkin_Platform.Core.Queries.Schedule;
using Checkin_Platform.Core.Queries.User;
using Checkin_Platform.Core.Queries.UserSchedule;
using Checkin_Platform.Core.QueryHandlers.Class;
using Checkin_Platform.Core.QueryHandlers.Classroom;
using Checkin_Platform.Core.QueryHandlers.ClassroomFeature;
using Checkin_Platform.Core.QueryHandlers.Feature;
using Checkin_Platform.Core.QueryHandlers.Schedule;
using Checkin_Platform.Core.QueryHandlers.User;
using Checkin_Platform.Core.QueryHandlers.UserSchedule;
using Checkin_Platform.Infrastructure.Data;
using System;
using System.Linq;

namespace Checkin_Platform.Console
{
    class Program
    {
        //public static void checkUsers(UnitOfWork unitOfWork)
        //{

        //    // dto
        //    var userDto1 = new SetUserDto
        //    {
        //        FirstName = "first",
        //        LastName = "user",
        //        Year = 1,
        //        Role = "Student",
        //        Department = "dpasd",
        //        Group = "aa12",
        //    };
        //    //-------------- create
        //    var createUserCommand = new CreateUserCommand()
        //    {
        //        UserDto = userDto1
        //    };

        //    var userCommandHandler = new CreateUserCommandHandler(unitOfWork);
        //    //userCommandHandler.Handle(createUserCommand, new System.Threading.CancellationToken()).Wait();

        //    //--------------- get
        //    var getUsersQuery = new GetUsersQuery();
        //    var userQueryHandler = new GetUsersQueryHandler(unitOfWork);
        //    var userResult = userQueryHandler.Handle(getUsersQuery, new System.Threading.CancellationToken());
        //    foreach (var item in userResult.Result.ToList())
        //    {
        //        System.Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName}");
        //    }

        //    //-------------- delete
        //    //var deleteUserCommand = new DeleteUserCommand()
        //    //{
        //    //    //Id = unitOfWork.UserRepository.GetUsers().OrderByDescending(c => c.Id).FirstOrDefault().Id
        //    //    //Id = 200
        //    //    Id = 1
        //    //};
        //    //var deleteUserHandler = new DeleteUserCommandHandler(unitOfWork);
        //    //deleteUserHandler.Handle(deleteUserCommand, new System.Threading.CancellationToken()).Wait();
        //    //System.Console.WriteLine();
        //    //userResult = userQueryHandler.Handle(getUsersQuery, new System.Threading.CancellationToken());
        //    //foreach (var item in userResult.Result.ToList())
        //    //{
        //    //    System.Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName}");
        //    //}

        //}
        //public static void checkClasses(UnitOfWork unitOfWork)
        //{

        //    //--------------dto
        //    var classDto1 = new SetClassDto
        //    {
        //        Teacher = unitOfWork.UserRepository.GetUsers().FirstOrDefault(),
        //        Name = "class 1",
        //        Section = "section 1",
        //        Year = 3
        //    };

        //    //------------create
        //    var createClassCommand1 = new CreateClassCommand()
        //    {
        //        ClassDto = classDto1
        //    };
        //    var classCommandHandler = new CreateClassCommandHandler(unitOfWork);
        //    classCommandHandler.Handle(createClassCommand1, new System.Threading.CancellationToken()).Wait();

        //    //------------------get
        //    var getClassesQuery = new GetClassesQuery();
        //    var classQueryHandler = new GetClassesQueryHandler(unitOfWork);
        //    var classResult = classQueryHandler.Handle(getClassesQuery, new System.Threading.CancellationToken());
        //    foreach (var item in classResult.Result.ToList())
        //    {
        //        System.Console.WriteLine(item.Id + " " + item.Name + " " + item.Section + " " + item.Year + " " + item.Teacher.FirstName);
        //    }

        //    //-----------------update
        //    //var class1 = unitOfWork.ClassRepository.GetClassById(12);
        //    //var updatedDto = new GetClassDto()
        //    //{
        //    //    Id = class1.Id,
        //    //    Name = class1.Name + " Updated",
        //    //    Section = class1.Section + " Updated",
        //    //    Teacher = class1.Teacher,
        //    //    Year = class1.Year
        //    //};
        //    //var updateClassCommand = new UpdateClassCommand() { ClassDto = updatedDto };
        //    //var updateClassCommandHandler = new UpdateClassCommandHandler(unitOfWork);
        //    //updateClassCommandHandler.Handle(updateClassCommand, new System.Threading.CancellationToken());
        //    //System.Console.WriteLine();
        //    //classResult = classQueryHandler.Handle(getClassesQuery, new System.Threading.CancellationToken());
        //    //foreach (var item in classResult.Result.ToList())
        //    //{
        //    //    System.Console.WriteLine(item.Id + " " + item.Name + " " + item.Section + " " + item.Year + " " + item.Teacher.FirstName);
        //    //}

        //    //-----------------delete
        //    //var deleteClassCommand = new DeleteClassCommand()
        //    //{
        //    //    //Id = unitOfWork.ClassRepository.GetClasses().OrderByDescending(c => c.Id).FirstOrDefault().Id
        //    //    Id = 200
        //    //};

        //    //var deleteClassHandler = new DeleteClassCommandHandler(unitOfWork);
        //    //deleteClassHandler.Handle(deleteClassCommand, new System.Threading.CancellationToken()).Wait();
        //    //System.Console.WriteLine();
        //    //classResult = classQueryHandler.Handle(getClassesQuery, new System.Threading.CancellationToken());
        //    //foreach (var item in classResult.Result.ToList())
        //    //{
        //    //    System.Console.WriteLine(item.Name + " " + item.Section + " " + item.Year + " " + item.Teacher.FirstName);
        //    //}
        //}
        //public static void checkClassrooms(UnitOfWork unitOfWork)
        //{

        //    //--------------dto
        //    var classroomDto1 = new SetClassroomDto
        //    {
        //        Name = "514",
        //        Capacity = 15,
        //        Location = "Bloc A"
        //    };

        //    //------------create
        //    var createClassroomCommand1 = new CreateClassroomCommand()
        //    {
        //        ClassroomDto = classroomDto1
        //    };
        //    var classroomCommandHandler = new CreateClassroomCommandHandler(unitOfWork);
        //    //classroomCommandHandler.Handle(createClassroomCommand1, new System.Threading.CancellationToken()).Wait();

        //    //------------------get
        //    var getClassroomsQuery = new GetClassroomsQuery();
        //    var classroomQueryHandler = new GetClassroomsQueryHandler(unitOfWork);
        //    var classroomResult = classroomQueryHandler.Handle(getClassroomsQuery, new System.Threading.CancellationToken());
        //    foreach (var item in classroomResult.Result.ToList())
        //    {
        //        System.Console.WriteLine($"{item.Id} {item.Name} {item.Capacity} {item.Location}");
        //    }

        //    //-----------------delete
        //    //var deleteClassroomCommand = new DeleteClassroomCommand()
        //    //{
        //    //    //Id = unitOfWork.ClassroomRepository.GetClassrooms().OrderByDescending(c => c.Id).FirstOrDefault().Id
        //    //    //Id = 200
        //    //    Id = 1
        //    //};

        //    //var deleteClassroomHandler = new DeleteClassroomCommandHandler(unitOfWork);
        //    //deleteClassroomHandler.Handle(deleteClassroomCommand, new System.Threading.CancellationToken()).Wait();
        //    //System.Console.WriteLine();
        //    //classroomResult = classroomQueryHandler.Handle(getClassroomsQuery, new System.Threading.CancellationToken());
        //    //foreach (var item in classroomResult.Result.ToList())
        //    //{
        //    //    System.Console.WriteLine($"{item.Id} {item.Name} {item.Capacity} {item.Location}");
        //    //}
        //}
        //public static void checkClassroomFeatures(UnitOfWork unitOfWork)
        //{

        //    //--------------dto
        //    var classroomFeatureDto1 = new SetClassroomFeatureDto
        //    {
        //        Classroom = unitOfWork.ClassroomRepository.GetClassrooms().FirstOrDefault(),
        //        Feature = unitOfWork.FeatureRepository.GetFeatures().FirstOrDefault()

        //    };

        //    //------------create
        //    var createClassroomFeatureCommand1 = new CreateClassroomFeatureCommand()
        //    {
        //        ClassroomFeatureDto = classroomFeatureDto1
        //    };
        //    var classroomFeatureCommandHandler = new CreateClassroomFeatureCommandHandler(unitOfWork);
        //   // classroomFeatureCommandHandler.Handle(createClassroomFeatureCommand1, new System.Threading.CancellationToken()).Wait();

        //    //------------------get
        //    var getClassroomFeaturesQuery = new GetClassroomFeaturesQuery();
        //    var classroomFeatureQueryHandler = new GetClassroomFeaturesQueryHandler(unitOfWork);
        //    var classroomFeatureResult = classroomFeatureQueryHandler.Handle(getClassroomFeaturesQuery, new System.Threading.CancellationToken());
        //    foreach (var item in classroomFeatureResult.Result.ToList())
        //    {
        //        System.Console.WriteLine($"{item.Id} {item.Classroom.Name} {item.Feature.Name}");
        //    }

        //    //-----------------delete
        //    //var deleteClassroomFeatureCommand = new DeleteClassroomFeatureCommand()
        //    //{
        //    //    Id = unitOfWork.ClassroomFeatureRepository.GetClassroomFeatures().OrderByDescending(c => c.Id).FirstOrDefault().Id
        //    //    //Id = 200
        //    //    //Id = 1
        //    //};

        //    //var deleteClassroomFeatureHandler = new DeleteClassroomFeatureCommandHandler(unitOfWork);
        //    //deleteClassroomFeatureHandler.Handle(deleteClassroomFeatureCommand, new System.Threading.CancellationToken()).Wait();
        //    //System.Console.WriteLine();
        //    //classroomFeatureResult = classroomFeatureQueryHandler.Handle(getClassroomFeaturesQuery, new System.Threading.CancellationToken());
        //    //foreach (var item in classroomFeatureResult.Result.ToList())
        //    //{
        //    //    System.Console.WriteLine($"{item.Id} {item.Classroom.Name} {item.Feature.Name}");
        //    //}
        //}
        //public static void checkFeatures(UnitOfWork unitOfWork)
        //{
        //    //--------------dto
        //    var featureDto1 = new SetFeatureDto
        //    {
        //        Name = "feature1"
        //    };

        //    //------------create
        //    var createFeatureCommand1 = new CreateFeatureCommand()
        //    {
        //        FeatureDto = featureDto1
        //    };
        //    var featureCommandHandler = new CreateFeatureCommandHandler(unitOfWork);
        //    //featureCommandHandler.Handle(createFeatureCommand1, new System.Threading.CancellationToken()).Wait();

        //    //------------------get
        //    var getFeaturesQuery = new GetFeaturesQuery();
        //    var featureQueryHandler = new GetFeaturesQueryHandler(unitOfWork);
        //    var featureResult = featureQueryHandler.Handle(getFeaturesQuery, new System.Threading.CancellationToken());
        //    foreach (var item in featureResult.Result.ToList())
        //    {
        //        System.Console.WriteLine($"{item.Id} {item.Name}");
        //    }
        //    System.Console.WriteLine();
        //    var getFeaturesByClassroomQuery = new GetFeaturesByClassroomQuery() { ClassroomId = 2 };
        //    var getFeaturesByClassroomQueryHandler = new GetFeaturesByClassroomQueryHandler(unitOfWork);
        //    var featuresByClassroomResult = getFeaturesByClassroomQueryHandler.Handle(getFeaturesByClassroomQuery, new System.Threading.CancellationToken());
        //    foreach(var item in featuresByClassroomResult.Result.ToList())
        //    {
        //        System.Console.WriteLine($"{item.Id} {item.Name}");
        //    }
        //    //-----------------delete
        //    //var deleteFeatureCommand = new DeleteFeatureCommand()
        //    //{
        //    //    Id = unitOfWork.FeatureRepository.GetFeatures().OrderByDescending(c => c.Id).FirstOrDefault().Id
        //    //    //Id = 200
        //    //};

        //    //var deleteFeatureHandler = new DeleteFeatureCommandHandler(unitOfWork);
        //    //deleteFeatureHandler.Handle(deleteFeatureCommand, new System.Threading.CancellationToken()).Wait();
        //    //System.Console.WriteLine();
        //    //featureResult = featureQueryHandler.Handle(getFeaturesQuery, new System.Threading.CancellationToken());
        //    //foreach (var item in featureResult.Result.ToList())
        //    //{
        //    //    System.Console.WriteLine($"{item.Id} {item.Name}");
        //    //}

        //}
        //public static void checkSchedules(UnitOfWork unitOfWork)
        //{
        //    //--------------dto
        //    var scheduleDto1 = new SetScheduleDto
        //    {
        //        Class = unitOfWork.ClassRepository.GetClasses().FirstOrDefault(),
        //        Classroom = unitOfWork.ClassroomRepository.GetClassrooms().FirstOrDefault(),
        //        DateTime = new DateTime(2021, 11, 15)

        //    };

        //    //------------create
        //    var createScheduleCommand1 = new CreateScheduleCommand()
        //    {
        //        ScheduleDto = scheduleDto1
        //    };
        //    var scheduleCommandHandler = new CreateScheduleCommandHandler(unitOfWork);
        //    //scheduleCommandHandler.Handle(createScheduleCommand1, new System.Threading.CancellationToken()).Wait();

        //    //------------------get
        //    var getSchedulesQuery = new GetSchedulesQuery();
        //    var scheduleQueryHandler = new GetSchedulesQueryHandler(unitOfWork);
        //    var scheduleResult = scheduleQueryHandler.Handle(getSchedulesQuery, new System.Threading.CancellationToken());
        //    foreach (var item in scheduleResult.Result.ToList())
        //    {
        //        System.Console.WriteLine($"{item.Id} {item.Class.Name} {item.Classroom.Name} {item.DateTime}");
        //    }
        //    System.Console.WriteLine();
        //    var getSchedulesByDateQuery = new GetSchedulesByDateQuery() { 
        //        DateTime = new DateTime(2021, 12, 15)
        //    };
        //    var getSchedulesByDateQueryHandler = new GetSchedulesByDateQueryHandler(unitOfWork);
        //    var schedulesByDateResult = getSchedulesByDateQueryHandler.Handle(getSchedulesByDateQuery, new System.Threading.CancellationToken());
        //    foreach(var item in schedulesByDateResult.Result.ToList()) 
        //    {
        //        System.Console.WriteLine($"{item.Id} {item.Class.Name} {item.Classroom.Name} {item.DateTime}");
        //    }
        //    System.Console.WriteLine();
        //    var getSchedulesByTeacherQuery = new GetSchedulesByTeacherQuery()
        //    {
        //        TeacherId = 1
        //    };
        //    var getSchedulesByTeacherQueryHandler = new GetSchedulesByTeacherQueryHandler(unitOfWork);
        //    var schedulesByTeacherResult = getSchedulesByTeacherQueryHandler.Handle(getSchedulesByTeacherQuery, new System.Threading.CancellationToken());
        //    foreach (var item in schedulesByTeacherResult.Result.ToList())
        //    {
        //        System.Console.WriteLine($"{item.Id} {item.Class.Name} {item.Classroom.Name} {item.DateTime}");
        //    }
        //    System.Console.WriteLine();
        //    var getSchedulesByUserReservationsQuery = new GetSchedulesByUserReservationsQuery()
        //    {
        //        UserId = 1
        //    };
        //    var getSchedulesByUserReservationsQueryHandler = new GetSchedulesByUserReservationsQueryHandler(unitOfWork);
        //    var schedulesByUserReservationsResult = getSchedulesByUserReservationsQueryHandler.Handle(getSchedulesByUserReservationsQuery, new System.Threading.CancellationToken());
        //    foreach (var item in schedulesByUserReservationsResult.Result.ToList())
        //    {
        //        System.Console.WriteLine($"{item.Id} {item.Class.Name} {item.Classroom.Name} {item.DateTime}");
        //    }
        //    //-----------------delete
        //    //var deleteScheduleCommand = new DeleteScheduleCommand()
        //    //{
        //    //    //Id = unitOfWork.ScheduleRepository.GetSchedules().OrderByDescending(c => c.Id).FirstOrDefault().Id
        //    //    //Id = 200
        //    //    Id = 1
        //    //};

        //    //var deleteScheduleHandler = new DeleteScheduleCommandHandler(unitOfWork);
        //    //deleteScheduleHandler.Handle(deleteScheduleCommand, new System.Threading.CancellationToken()).Wait();
        //    //System.Console.WriteLine();
        //    //scheduleResult = scheduleQueryHandler.Handle(getSchedulesQuery, new System.Threading.CancellationToken());
        //    //foreach (var item in scheduleResult.Result.ToList())
        //    //{
        //    //    System.Console.WriteLine($"{item.Id} {item.Class.Name} {item.Classroom.Name} {item.DateTime}");
        //    //}
        //}
        //public static void checkUserSchedules(UnitOfWork unitOfWork)
        //{
        //    //--------------dto
        //    var userScheduleDto1 = new SetUserScheduleDto
        //    {
        //        Schedule = unitOfWork.ScheduleRepository.GetSchedules().FirstOrDefault(),
        //        User = unitOfWork.UserRepository.GetUsers().FirstOrDefault()

        //    };

        //    //------------create
        //    var createUserScheduleCommand1 = new CreateUserScheduleCommand()
        //    {
        //        UserScheduleDto = userScheduleDto1
        //    };
        //    var userScheduleCommandHandler = new CreateUserScheduleCommandHandler(unitOfWork);
        //    //userScheduleCommandHandler.Handle(createUserScheduleCommand1, new System.Threading.CancellationToken()).Wait();

        //    //------------------get
        //    var getUserSchedulesQuery = new GetUserSchedulesQuery();
        //    var userScheduleQueryHandler = new GetUserSchedulesQueryHandler(unitOfWork);
        //    var userScheduleResult = userScheduleQueryHandler.Handle(getUserSchedulesQuery, new System.Threading.CancellationToken());
        //    foreach (var item in userScheduleResult.Result.ToList())
        //    {
        //        System.Console.WriteLine($"{item.Id} {item.User.FirstName} {item.Schedule.DateTime}");
        //    }

        //    //-----------------delete
        //    //var deleteUserScheduleCommand = new DeleteUserScheduleCommand()
        //    //{
        //    //    Id = unitOfWork.UserScheduleRepository.GetUserSchedules().OrderByDescending(c => c.Id).FirstOrDefault().Id
        //    //    //Id = 200
        //    //};

        //    //var deleteUserScheduleHandler = new DeleteUserScheduleCommandHandler(unitOfWork);
        //    //deleteUserScheduleHandler.Handle(deleteUserScheduleCommand, new System.Threading.CancellationToken()).Wait();
        //    //System.Console.WriteLine();
        //    //userScheduleResult = userScheduleQueryHandler.Handle(getUserSchedulesQuery, new System.Threading.CancellationToken());
        //    //foreach (var item in userScheduleResult.Result.ToList())
        //    //{
        //    //    System.Console.WriteLine($"{item.Id} {item.User.FirstName} {item.Schedule.DateTime}");
        //    //}
        //}
        static void Main(string[] args)
        {
            var unitOfWork = new UnitOfWork(new AppDbContext());
 
            //checkUsers(unitOfWork);
            //checkClasses(unitOfWork);
            //checkClassrooms(unitOfWork);
            //checkFeatures(unitOfWork);
            //checkSchedules(unitOfWork);
            //checkClassroomFeatures(unitOfWork);
            //checkUserSchedules(unitOfWork);
        }
    }
}
