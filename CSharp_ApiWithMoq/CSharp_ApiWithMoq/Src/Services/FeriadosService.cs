using CSharp_ApiWithMoq.Data.Interface;
using CSharp_ApiWithMoq.Src.Models;

namespace CSharp_ApiWithMoq.Src.Services
{
    public class FeriadosService
    {
        private readonly IFeriadoRepository _FeriadoRepository;

        public FeriadosService(IFeriadoRepository FeriadoRepository)
        {
            _FeriadoRepository = FeriadoRepository;
        }

        public async Task<IEnumerable<Feriados>> GetAllFeriados()
        {
            return await _FeriadoRepository.GetAllFeriados();
        }

        public async Task<Feriados> GetFeriadoById(int id)
        {
            return await _FeriadoRepository.GetFeriadoById(id);
        }

        public async Task AddFeriado(Feriados Feriado)
        {
            await _FeriadoRepository.AddFeriado(Feriado);
        }

        public async Task UpdateFeriado(Feriados Feriado)
        {
            await _FeriadoRepository.UpdateFeriado(Feriado);
        }

        public async Task DeleteFeriado(int id)
        {
            await _FeriadoRepository.DeleteFeriado(id);
        }
    }
}
