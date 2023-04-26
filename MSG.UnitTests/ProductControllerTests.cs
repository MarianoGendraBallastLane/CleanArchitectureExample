using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MSG.Application.Features.ProductFeatures.GetAllProduct;
using MSG.WebApi.Controllers;

namespace MSG.UnitTests
{
    [TestFixture]
    public class ProductControllerTests
    {
        private ProductController _target;
        private Mock<IMediator> _mediatorMock;
        private CancellationToken _cancellationToken;

        [SetUp]
        public void Setup()
        {  
            _cancellationToken = new CancellationToken();
            _mediatorMock = new Mock<IMediator>();
            _mediatorMock
                .Setup(c => c.Send(It.IsAny<GetAllProductRequest>(), _cancellationToken))
                .ReturnsAsync(new List<GetAllProductResponse>
                {
                    new GetAllProductResponse
                    {
                        Id = new Guid(),
                        Name = "Test Product A",
                        Quantity = 1
                    },
                    new GetAllProductResponse
                    {
                        Id = new Guid(),
                        Name = "Test Product B",
                        Quantity = 10
                    }
                });
            _target = new ProductController(_mediatorMock.Object);
        }

        [Test]
        public async Task GetAll_ShouldReturnAListOfProducts()
        {
            //Arrange

            //Act
            var result = await _target.GetAll(_cancellationToken);
            var resultData = result.Result as OkObjectResult;

            //Assert
 
            Assert.IsInstanceOf<ActionResult<List<GetAllProductResponse>>>(result);
            Assert.IsNotNull(resultData);
            Assert.IsNotNull(resultData.Value);
            Assert.IsInstanceOf<List<GetAllProductResponse>>(resultData.Value);
            Assert.IsNotEmpty((List<GetAllProductResponse>)resultData.Value);
        }
    }
}