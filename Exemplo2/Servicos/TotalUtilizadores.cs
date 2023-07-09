using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;


namespace Exemplo2.Servicos
{
    public class TotalUtilizadores
    {
        public long TUtilizadores()
        {
            Random rand = new Random();
            return rand.Next(100, int.MaxValue);
        }
    }
}
