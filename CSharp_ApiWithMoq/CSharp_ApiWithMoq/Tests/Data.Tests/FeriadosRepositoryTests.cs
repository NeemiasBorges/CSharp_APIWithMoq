using CSharp_ApiWithMoq.Data;
using CSharp_ApiWithMoq.Data.Interface;
using CSharp_ApiWithMoq.Src.Models;
using Xunit;

namespace Data.Tests
{
    public class FeriadosRepositoryTests
    {
        private readonly IFeriadoRepository _repository;


        [Fact]
        public async Task GetAllFeriados_ReturnsAllFeriados()
        {
            var result = await _repository.GetAllFeriados();
            Assert.NotNull(result);
            Assert.IsType<List<Feriados>>(result);
        }

        [Fact]
        public async Task GetFeriadoById_ReturnsFeriado_WhenExists()
        {
            var result = await _repository.GetFeriadoById(1);
            Assert.NotNull(result);
            Assert.IsType<Feriados>(result);
            Assert.Equal(1, result.Id);
        }
    }
}
