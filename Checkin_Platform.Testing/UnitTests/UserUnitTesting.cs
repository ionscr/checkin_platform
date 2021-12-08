using AutoMapper;
using Checkin_Platform.Controllers;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.User;
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
	public class UserUnitTesting
	{
		private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
		private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
		private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

		[TestMethod]
		public async Task Get_Users_GetUsersQueryIsCalled()
		{
			//Arrange
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			//Act
			var controller = new UserController(_mockUnitOfWork.Object, _mockMediator.Object);
			await controller.GetUsers();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}
		[TestMethod]
		public async Task Get_Users_Return_OkResult()
		{
			//Arrange  
			var controller = new UserController(_mockUnitOfWork.Object, _mockMediator.Object);

			//Act  
			var data = await controller.GetUsers();

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Post_User_Return_OkResult()
		{
			//Arrange  
			var controller = new UserController(_mockUnitOfWork.Object, _mockMediator.Object);
			var user = new SetUserDto()
			{
				Department = "asd",
				FirstName = "asd",
				Group = "asd",
				LastName = "sd",
				Role = "Student",
				Year = 2
			};

			//Act  
			var data = await controller.CreateUser(user);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Put_User_Return_OkResult()
		{
			//Arrange  
			var controller = new UserController(_mockUnitOfWork.Object, _mockMediator.Object);
			var user = new GetUserDto()
			{
				Id = 1
			};

			//Act  
			var data = await controller.UpdateUser(user);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Delete_User_Return_OkResult()
		{
			//Arrange  
			var controller = new UserController(_mockUnitOfWork.Object, _mockMediator.Object);
			var user = 1;
			//Act  
			var data = await controller.DeleteUser(user);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
	}
}

