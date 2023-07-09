using Exemplo3APIs.Repositorio;
using Exemplo3APIs.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo3APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : Controller
    {
        private readonly IReservasRepositorio _reservasRepositorio;
        public ReservasController(IReservasRepositorio reservasRepositorio)
        {
            _reservasRepositorio = reservasRepositorio;

        }

        [HttpGet]
        public async Task<IEnumerable<Reservas>> GetReservas()
        {
            return await _reservasRepositorio.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservas>> GetReservas(int id)
        {
            return await _reservasRepositorio.Get(id);
        }


        [HttpPost]
        public async Task<ActionResult<Reservas>> PostReservas([FromBody] Reservas reservas)
        {
            var novaReserva = await _reservasRepositorio.Criar(reservas);
            return CreatedAtAction(nameof(GetReservas), new { id = novaReserva.Id }, novaReserva);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservas>> Delete(int id)
        {
            var reservasToDelete = await _reservasRepositorio.Get(id);

            if (reservasToDelete == null)

                return NotFound();

            await _reservasRepositorio.Delete(reservasToDelete.Id);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Reservas>> PutReservas(int id, [FromBody] Reservas reservas)
        {


            if (id != reservas.Id)
                return BadRequest();



            await _reservasRepositorio.Update(reservas);

            return NoContent();
        }

    }
}
