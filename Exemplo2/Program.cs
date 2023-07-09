using Configuracoes.Middlewares;
using Exemplo2.Middlewares;
using Exemplo2.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddSingleton<TotalUtilizadores>();
//builder.Services.AddSingleton<IServicoGUID, ServicoGuid>();
//builder.Services.AddTransient<IServicoGUID, ServicoGuid>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

/*if (!app.Environment.IsStaging())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/

if (!app.Environment.IsProduction())
{
    app.UseMiddleware<EdicaoRespostaMiddleware>();
    app.UseMiddleware<EdicaoSolicitacaoMiddleware>();
    app.UseMiddleware<CurtoCircuitoMiddleware>();
    app.UseMiddleware<ConteudoMiddleware>();
}



app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}") ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
