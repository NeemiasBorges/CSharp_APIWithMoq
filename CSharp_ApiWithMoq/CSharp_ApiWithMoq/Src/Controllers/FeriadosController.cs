using CSharp_ApiWithMoq.Src.Models;
using CSharp_ApiWithMoq.Src.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Serilog;

namespace Api.Controllers.V1
{
    [Route("api/v1/Feriado")]
    [ApiController]
    public class FeriadoController : ControllerBase
    {
        private readonly FeriadosService _Feriadoervice;

        public FeriadoController(FeriadosService Feriadoervice)
        {
            _Feriadoervice = Feriadoervice;
        }

        /// <summary>
        /// Coleta e retorna todos os feriados da base de dados.
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Feriados>>> GetAllFeriados()
        {
            try
            {
                var Feriado = await _Feriadoervice.GetAllFeriados();
                return Ok(Feriado);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao obter todos os feriados.");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao processar a solicitação.");
            }
        }

        /// <summary>
        /// Obtem algum feriado de acrodo com o ID existente na base de dados.
        /// </summary>
        [HttpGet("{id}", Name = "GetFeriadoById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Feriados>> GetFeriadoById(int id)
        {
            try
            {
                var Feriado = await _Feriadoervice.GetFeriadoById(id);
                if (Feriado == null)
                {
                    return NotFound();
                }
                return Ok(Feriado);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao obter feriado com ID {Id}.", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao processar a solicitação.");
            }
        }

        /// <summary>
        /// Adicionar um novo feriado.
        /// </summary>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Feriados>> AddFeriado([FromBody] Feriados Feriado)
        {
            if (Feriado == null || string.IsNullOrEmpty(Feriado.Name))
            {
                return BadRequest("Invalid Feriado data.");
            }

            try
            {
                await _Feriadoervice.AddFeriado(Feriado);
                return CreatedAtRoute("GetFeriadoById", new { id = Feriado.Id }, Feriado);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao adicionar feriado.");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao processar a solicitação.");
            }
        }

        /// <summary>
        /// Atualiza um feriado existente.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdateFeriado(int id, [FromBody] Feriados Feriado)
        {
            if (id != Feriado.Id)
            {
                return BadRequest("Feriado ID mismatch.");
            }

            try
            {
                var existingFeriado = await _Feriadoervice.GetFeriadoById(id);
                if (existingFeriado == null)
                {
                    return NotFound();
                }

                await _Feriadoervice.UpdateFeriado(Feriado);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao atualizar feriado com ID {Id}.", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao processar a solicitação.");
            }
        }


        /// <summary>
        /// Deleta feriado por ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteFeriado(int id)
        {
            try
            {
                var existingFeriado = await _Feriadoervice.GetFeriadoById(id);
                if (existingFeriado == null)
                {
                    return NotFound();
                }

                await _Feriadoervice.DeleteFeriado(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao deletar feriado com ID {Id}.", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao processar a solicitação.");
            }
        }
    }
}