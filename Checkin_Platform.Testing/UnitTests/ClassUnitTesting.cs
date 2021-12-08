using AutoMapper;
using Checkin_Platform.Controllers;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Class;
using Checkin_Platform.Domain;
using Checkin_Platform.Infrastructure.Data;
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
	public class ClassUnitTesting
	{
		private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
		private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();

		[TestMethod]
		public async Task Get_Classes_GetClassesQueryIsCalled()
		{
			//Arrange
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetClassesQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			//Act
			var controller = new ClassController(_mockUnitOfWork.Object, _mockMediator.Object);
			await controller.GetClasses();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetClassesQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}
		[TestMethod]
		public async Task Get_Classes_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassController(_mockUnitOfWork.Object, _mockMediator.Object);

			//Act  
			var data = await controller.GetClasses();

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Post_Class_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassController(_mockUnitOfWork.Object, _mockMediator.Object);
			var class_to_post = new SetClassDto() 
			{
				Name = "TestName",
				Section = "TestSection",
				Year = 123,
				UserId = 3
			};

			//Act  
			var data = await controller.CreateClass(class_to_post);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Put_Class_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassController(_mockUnitOfWork.Object, _mockMediator.Object);
			var class_to_update = new GetClassDto()
			{
				Id = 1,
				Name = "asd"
			};

			//Act  
			var data = await controller.UpdateClass(class_to_update);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Delete_Class_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassController(_mockUnitOfWork.Object, _mockMediator.Object);
			var class_to_delete = 1;
			//Act  
			var data = await controller.DeleteClass(class_to_delete);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
	}
}

