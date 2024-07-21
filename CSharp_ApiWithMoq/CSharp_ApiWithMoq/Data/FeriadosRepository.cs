using CSharp_ApiWithMoq.Data.Interface;
using CSharp_ApiWithMoq.Src.Models;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;

namespace CSharp_ApiWithMoq.Data
{
    public class FeriadosRepository : IFeriadoRepository
    {
        private readonly IDistributedCache _redis;

        public FeriadosRepository(IDistributedCache redis)
        {
            _redis = redis ?? throw new ArgumentNullException(nameof(redis));
        }
        public async Task<Feriados> GetFeriadoById(int id)
        {
            var data = await _redis.GetStringAsync(id.ToString());

            if (string.IsNullOrEmpty(data)) return null;

            var feriado = JsonSerializer.Deserialize<Feriados>(data);
            return feriado;
        }

        public async Task AddFeriado(Feriados Feriados)
        {
            await _redis.SetStringAsync(Feriados.Id.ToString(), JsonSerializer.Serialize(Feriados));
        }

        public async Task UpdateFeriado(Feriados Feriados)
        {
            await _redis.SetStringAsync(Feriados.Id.ToString(), JsonSerializer.Serialize(Feriados));
        }

        public async Task DeleteFeriado(int id)
        {
            await _redis.RemoveAsync(id.ToString());
        }

        public async Task<IEnumerable<Feriados>> GetAllFeriados()
        {
            return await _redis.GetStringAsync("Feriados") switch
            {
                null => null,
                string data => JsonSerializer.Deserialize<IEnumerable<Feriados>>(data)
            };
        }
    }
}