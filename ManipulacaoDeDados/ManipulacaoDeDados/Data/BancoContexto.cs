using ManipulacaoDeDados.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ManipulacaoDeDados.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto (DbContextOptions<BancoContexto> options) : base(options)
        {
        }
        public DbSet<ContatoModelo> Contatos { get; set; }
    }
}
