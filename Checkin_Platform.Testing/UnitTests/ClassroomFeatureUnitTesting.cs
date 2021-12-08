using AutoMapper;
using Checkin_Platform.Controllers;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.ClassroomFeature;
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
	public class ClassroomFeatureUnitTesting
	{
		private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
		private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
		private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

		[TestMethod]
		public async Task Get_ClassroomFeatures_GetClassroomFeaturesQueryIsCalled()
		{
			//Arrange
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetClassroomFeaturesQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			//Act
			var controller = new ClassroomFeatureController(_mockUnitOfWork.Object, _mockMediator.Object);
			await controller.GetClassroomFeatures();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetClassroomFeaturesQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}
		[TestMethod]
		public async Task Get_ClassroomFeatures_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassroomFeatureController(_mockUnitOfWork.Object, _mockMediator.Object);

			//Act  
			var data = await controller.GetClassroomFeatures();

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Post_ClassroomFeature_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassroomFeatureController(_mockUnitOfWork.Object, _mockMediator.Object);
			var classroomFeature = new SetClassroomFeatureDto()
			{
				ClassroomId = 1,
				FeatureId = 1
			};

			//Act  
			var data = await controller.CreateClassroomFeature(classroomFeature);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}

		[TestMethod]
		public async Task Delete_ClassroomFeature_Return_OkResult()
		{
			//Arrange  
			var controller = new ClassroomFeatureController(_mockUnitOfWork.Object, _mockMediator.Object);
			var classroomFeature = 1;
			//Act  
			var data = await controller.DeleteClassroomFeature(classroomFeature);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
	}
}

