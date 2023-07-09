using Exemplo3APIs.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Exemplo3APIs.Repositorio
{
    public class ReservasRepositorio : IReservasRepositorio
    {
        public readonly ReservasContexto _reservasContexto;

        public  ReservasRepositorio (ReservasContexto reservasContexto)
        {
            _reservasContexto = reservasContexto;
        }

        public async Task<Reservas> Criar(Reservas reservas)
        {
            _reservasContexto.Reservas.Add(reservas);
            await _reservasContexto.SaveChangesAsync();

            return reservas;
        }

        public async Task Delete(int id)
        {
            var reservasToDelete = await _reservasContexto.Reservas.FindAsync(id);
            _reservasContexto.Reservas.Remove(reservasToDelete);
            await _reservasContexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservas>> Get()
        {
            return await _reservasContexto.Reservas.ToListAsync();
        }

        public async Task<Reservas> Get(int id)
        {
            return await _reservasContexto.Reservas.FindAsync(id);
        }

        public async Task Update(Reservas reservas)
        {
            _reservasContexto.Entry(reservas).State = EntityState.Modified;
            await _reservasContexto.SaveChangesAsync();
        }
    }
}
