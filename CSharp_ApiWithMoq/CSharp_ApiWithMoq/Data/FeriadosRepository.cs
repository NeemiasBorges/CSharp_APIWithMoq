using CSharp_ApiWithMoq.Data.Interface;
using CSharp_ApiWithMoq.Src.Models;

namespace CSharp_ApiWithMoq.Data
{
    public class FeriadosRepository : IFeriadoRepository
    {
        private readonly List<Feriados> _Feriados;
        public FeriadosRepository()
        {
            _Feriados = new List<Feriados>
            {
                new Feriados(1, "Ano Novo", new DateTime(DateTime.Now.Year, 1, 1), true),
                new Feriados(2, "Carnaval", new DateTime(DateTime.Now.Year, 2, 21), true), 
                new Feriados(3, "Sexta-Feira Santa", new DateTime(DateTime.Now.Year, 4, 7), true), 
                new Feriados(4, "Páscoa", new DateTime(DateTime.Now.Year, 4, 9), true),
                new Feriados(5, "Tiradentes", new DateTime(DateTime.Now.Year, 4, 21), true),
                new Feriados(6, "Dia do Trabalho", new DateTime(DateTime.Now.Year, 5, 1), true),
                new Feriados(7, "Independência do Brasil", new DateTime(DateTime.Now.Year, 9, 7), true),
                new Feriados(8, "Nossa Senhora Aparecida", new DateTime(DateTime.Now.Year, 10, 12), true),
                new Feriados(9, "Finados", new DateTime(DateTime.Now.Year, 11, 2), true),
                new Feriados(10, "Proclamação da República", new DateTime(DateTime.Now.Year, 11, 15), true),
                new Feriados(11, "Natal", new DateTime(DateTime.Now.Year, 12, 25), true)
            };
        }

        public async Task<Feriados> GetFeriadoById(int id)
        {
            return _Feriados.FirstOrDefault(h => h.Id == id);
        }

        public async Task AddFeriado(Feriados Feriados)
        {
             _Feriados.Add(Feriados);
        }

        public async Task UpdateFeriado(Feriados Feriados)
        {
            var existingFeriados = await GetFeriadoById(Feriados.Id);
            if (existingFeriados != null)
            {
                existingFeriados.Name = Feriados.Name;
                existingFeriados.Date = Feriados.Date;
                existingFeriados.IsNational = Feriados.IsNational;
            }
        }

        public async Task DeleteFeriado(int id)
        {
            var Feriados = await GetFeriadoById(id);
            if (Feriados != null)
            {
                _Feriados.Remove(Feriados);
            }
        }

        public async Task<IEnumerable<Feriados>> GetAllFeriados()
        {
            return _Feriados;
        }
    }
}