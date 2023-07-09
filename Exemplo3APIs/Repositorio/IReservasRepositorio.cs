using Exemplo3APIs.Modelos;

namespace Exemplo3APIs.Repositorio
{
    public interface IReservasRepositorio
    {
        Task<IEnumerable<Reservas>> Get();

        Task<Reservas> Get(int id);

        Task<Reservas> Criar(Reservas reservas);

        Task Update(Reservas reservas);

        Task Delete(int id);

    }
}
