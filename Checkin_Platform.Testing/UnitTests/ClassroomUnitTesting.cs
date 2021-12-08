using AutoMapper;
using Checkin_Platform.Controllers;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Classroom;
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
	public class ClassroomUnitTesting
	{
		private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
		private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
		private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

		[TestMethod]
		public async Task Get_Classroomes_GetClassroomsQueryIsCalled()
		{
			//Arrange
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetClassroomsQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			//Act
			var controller = new ClassroomController(_mockUnitOfWork.Object, _mockMediator.Object);
			await controller.GetClassrooms();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetClassroomsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}
		[TestMethod]
		public async Task Get_Classrooms_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassroomController(_mockUnitOfWork.Object, _mockMediator.Object);

			//Act  
			var data = await controller.GetClassrooms();

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Post_Classroom_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassroomController(_mockUnitOfWork.Object, _mockMediator.Object);
			var classroom = new SetClassroomDto()
			{
				Name = "testname",
				Capacity = 12,
				Location = "123"
			};

			//Act  
			var data = await controller.CreateClassroom(classroom);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Put_Classroom_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassroomController(_mockUnitOfWork.Object, _mockMediator.Object);
			var classroom = new GetClassroomDto()
			{
				Id = 1,
				Name = "asd"
			};

			//Act  
			var data = await controller.UpdateClassroom(classroom);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Delete_Classroom_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassroomController(_mockUnitOfWork.Object, _mockMediator.Object);
			var classroom = 1;
			//Act  
			var data = await controller.DeleteClassroom(classroom);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
	}
}

