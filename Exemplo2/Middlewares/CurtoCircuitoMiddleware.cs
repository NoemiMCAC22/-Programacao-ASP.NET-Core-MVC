using System.Threading.Tasks;
using Exemplo2.Servicos;
using Microsoft.AspNetCore.Http;

namespace Exemplo2.Middlewares
{
    public class CurtoCircuitoMiddleware
    {
        private RequestDelegate proxDelegate;
        
        public CurtoCircuitoMiddleware(RequestDelegate proximo) => proxDelegate= proximo;
        
        public async Task Invoke(HttpContext httpContexto)
        {
            // if (httpContexto.Request.Headers["User-Agent"].Any(v => v.Contains("Chrome")))
            if (httpContexto.Items["Chrome"] as bool? == true)
            {
                httpContexto.Response.StatusCode = StatusCodes.Status401Unauthorized;

            }
            else
            {
                await proxDelegate.Invoke(httpContexto);
            }

        }
    }
}

