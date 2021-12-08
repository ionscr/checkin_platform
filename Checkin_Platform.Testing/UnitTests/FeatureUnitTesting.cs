using AutoMapper;
using Checkin_Platform.Controllers;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Feature;
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
	public class FeatureUnitTesting
	{
		private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
		private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
		private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

		[TestMethod]
		public async Task Get_Features_GetFeaturesQueryIsCalled()
		{
			//Arrange
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetFeaturesQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();

			//Act
			var controller = new FeatureController(_mockUnitOfWork.Object, _mockMediator.Object);
			await controller.GetFeatures();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetFeaturesQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}
		[TestMethod]
		public async Task Get_Features_Return_OkResult()
		{
			//Arrange  
			var controller = new FeatureController(_mockUnitOfWork.Object, _mockMediator.Object);

			//Act  
			var data = await controller.GetFeatures();

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Post_Feature_Return_OkResult()
		{
			//Arrange  
			var controller = new FeatureController(_mockUnitOfWork.Object, _mockMediator.Object);
			var feature = new SetFeatureDto()
			{
				Name = "asd"
			};

			//Act  
			var data = await controller.CreateFeature(feature);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Put_Feature_Return_OkResult()
		{
			//Arrange  
			var controller = new FeatureController(_mockUnitOfWork.Object, _mockMediator.Object);
			var feature = new GetFeatureDto()
			{
				Id = 1,
				Name = "asd"
			};

			//Act  
			var data = await controller.UpdateFeature(feature);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
		[TestMethod]
		public async Task Delete_Feature_Return_OkResult()
		{
			//Arrange  
			var controller = new FeatureController(_mockUnitOfWork.Object, _mockMediator.Object);
			var feature = 1;
			//Act  
			var data = await controller.DeleteFeature(feature);

			//Assert  
			var okResult = data.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}
	}
}

