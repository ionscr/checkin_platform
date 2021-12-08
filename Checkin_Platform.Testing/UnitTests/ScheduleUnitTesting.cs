using AutoMapper;
using Checkin_Platform.Controllers;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Schedule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Testing.UnitTests
{
	[TestClass]
	public class ScheduleUnitTesting
	{
		private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
		private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
		private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

		[TestMethod]
		public async Task Get_Schedules_GetSchedulesQueryIsCalled()
		{
			//Arrange
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetSchedulesQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			//Act
			var controller = new ScheduleController(_mockUnitOfWork.Object, _mockMediator.Object);
			await controller.GetSchedules();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetSchedulesQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}
		[TestMethod]
		public async Task Get_Schedules_Return_OkResult()
		{
			//Arrange  
			var controller = new ScheduleController(_mockUnitOfWork.Object, _mockMediator.Object);

			//Act  
			var data = await controller.GetSchedules();

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Post_Schedule_Return_OkResult()
		{
			//Arrange  
			var controller = new ScheduleController(_mockUnitOfWork.Object, _mockMediator.Object);
			var schedule = new SetScheduleDto()
			{
				ClassroomId = 1,
				ClassId = 1,
				DateTime = System.DateTime.Now
			};

			//Act  
			var data = await controller.CreateSchedule(schedule);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Put_Schedule_Return_OkResult()
		{
			//Arrange  
			var controller = new ScheduleController(_mockUnitOfWork.Object, _mockMediator.Object);
			var schedule = new GetScheduleDto()
			{
				Id = 1
			};

			//Act  
			var data = await controller.UpdateSchedule(schedule);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Delete_Schedule_Return_OkResult()
		{
			//Arrange  
			var controller = new ScheduleController(_mockUnitOfWork.Object, _mockMediator.Object);
			var schedule = 1;
			//Act  
			var data = await controller.DeleteSchedule(schedule);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
	}
}

