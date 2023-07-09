using Microsoft.EntityFrameworkCore;

namespace Exemplo3APIs.Modelos
{
    public class ReservasContexto : DbContext
    {
        public ReservasContexto(DbContextOptions<ReservasContexto> opcoes) : base(opcoes)
        {
            Database.EnsureCreated();
        }

        public DbSet<Reservas> Reservas { get; set; }

        
    }
}
