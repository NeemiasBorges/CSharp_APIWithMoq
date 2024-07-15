using Api.Controllers.V1;
using CSharp_ApiWithMoq.Src.Models;
using CSharp_ApiWithMoq.Src.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Tests
{
    public class FeriadoControllerTests
    {
        private readonly Mock<FeriadosService> _mockService;
        private readonly FeriadoController _controller;

        public FeriadoControllerTests()
        {
            _mockService = new Mock<FeriadosService>();
            _controller = new FeriadoController(_mockService.Object);
        }

        [Fact]
        public async Task GetAllFeriados_ReturnsOkResult()
        {
            _mockService.Setup(service => service.GetAllFeriados())
                        .ReturnsAsync(new List<Feriados> { new Feriados(1, "Ano Novo", DateTime.Now, true) });

            var result = await _controller.GetAllFeriados();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsAssignableFrom<IEnumerable<Feriados>>(okResult.Value);
        }

        [Fact]
        public async Task GetFeriadoById_ReturnsNotFound_WhenFeriadoDoesNotExist()
        {
            _mockService.Setup(service => service.GetFeriadoById(It.IsAny<int>()))
                        .ReturnsAsync((Feriados)null);

            var result = await _controller.GetFeriadoById(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
