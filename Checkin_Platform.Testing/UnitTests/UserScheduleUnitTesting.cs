using AutoMapper;
using Checkin_Platform.Controllers;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.UserSchedule;
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
	public class UserScheduleUnitTesting
	{
		private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
		private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
		private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

		[TestMethod]
		public async Task Get_UserSchedules_GetUserSchedulesQueryIsCalled()
		{
			//Arrange
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetUserSchedulesQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			//Act
			var controller = new UserScheduleController(_mockUnitOfWork.Object, _mockMediator.Object);
			await controller.GetUserSchedules();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetUserSchedulesQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}
		[TestMethod]
		public async Task Get_UserSchedules_Return_OkResult()
		{
			//Arrange  
			var controller = new UserScheduleController(_mockUnitOfWork.Object, _mockMediator.Object);

			//Act  
			var data = await controller.GetUserSchedules();

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Post_UserSchedule_Return_OkResult()
		{
			//Arrange  
			var controller = new UserScheduleController(_mockUnitOfWork.Object, _mockMediator.Object);
			var userSchedule = new SetUserScheduleDto()
			{
				ScheduleId = 1,
				UserId = 1
			};

			//Act  
			var data = await controller.CreateUserSchedule(userSchedule);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Delete_UserSchedule_Return_OkResult()
		{
			//Arrange  
			var controller = new UserScheduleController(_mockUnitOfWork.Object, _mockMediator.Object);
			var userSchedule = 1;
			//Act  
			var data = await controller.DeleteUserSchedule(userSchedule);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
	}
}

