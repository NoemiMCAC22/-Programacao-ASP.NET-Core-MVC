namespace Exemplo2.Middlewares
{
    public class EdicaoRespostaMiddleware
    {
        private RequestDelegate proxDelegate;

        public EdicaoRespostaMiddleware(RequestDelegate proximo)
        {
            proxDelegate = proximo;

        }
        public async Task Invoke(HttpContext httpContext)
        {
            await proxDelegate.Invoke(httpContext);

            if (httpContext.Response.StatusCode == 401)
            {
                await httpContext.Response.WriteAsync("Este Browser  nao esta autorizado");

            }
            else if(httpContext.Response.StatusCode == 401)
            {
                await httpContext.Response.WriteAsync("Sem resposta do gerenciador");
            }


        }
    }
}
