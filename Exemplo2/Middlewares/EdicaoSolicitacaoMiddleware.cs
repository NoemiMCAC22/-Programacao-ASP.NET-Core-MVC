namespace Exemplo2.Middlewares
{
    public class EdicaoSolicitacaoMiddleware
    {
        private RequestDelegate proxDelegate;

        public EdicaoSolicitacaoMiddleware(RequestDelegate proximo) => proxDelegate = proximo;

        public async Task Invoke(HttpContext httpContexto)
        {
            httpContexto.Items["Chrome"] = httpContexto.Request.Headers["User-Agent"].Any(v => v.Contains("Chrome"));

            await proxDelegate.Invoke(httpContexto);
            }

        }
}


