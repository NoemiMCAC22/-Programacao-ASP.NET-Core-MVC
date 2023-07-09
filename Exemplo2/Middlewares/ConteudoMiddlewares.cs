using System.Threading.Tasks;
using Exemplo2.Servicos;
using Microsoft.AspNetCore.Http;

namespace Configuracoes.Middlewares

{
    public class ConteudoMiddleware
    {
        private RequestDelegate proxDelegate;
        private TotalUtilizadores totalUtilizadores;
        public ConteudoMiddleware(RequestDelegate proximo, TotalUtilizadores totalUti)
        {
            proxDelegate = proximo;
            totalUtilizadores = totalUti;

        }

        public async Task Invoke(HttpContext httpContexto)
        {
            if (httpContexto.Request.Path.ToString() == "/middleware")
            {
                await httpContexto.Response.WriteAsync("Isto e do conteudo do middleware, Total de utilizadores: " + totalUtilizadores.TUtilizadores());

            }
            else
            {
                await proxDelegate.Invoke(httpContexto);
            }

        }
    }
}