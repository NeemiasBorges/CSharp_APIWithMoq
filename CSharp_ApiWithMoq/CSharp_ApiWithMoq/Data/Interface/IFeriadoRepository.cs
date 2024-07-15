using CSharp_ApiWithMoq.Src.Models;

namespace CSharp_ApiWithMoq.Data.Interface
{
    public interface IFeriadoRepository
    {
        Task<IEnumerable<Feriados>> GetAllFeriados();
        Task<Feriados> GetFeriadoById(int id);
        Task AddFeriado(Feriados holiday);
        Task UpdateFeriado(Feriados holiday);
        Task DeleteFeriado(int id);
    }
}
