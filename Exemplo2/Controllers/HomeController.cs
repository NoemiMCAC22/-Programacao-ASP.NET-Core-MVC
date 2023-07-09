using Exemplo2.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo2.Controllers
{
    public class HomeController : Controller
    {
        
        private TotalUtilizadores totalUti;

    public HomeController( TotalUtilizadores total) 
        {
            totalUti = total;
           
        }
        public string Index()
        {
            
            return "Total de Utilizadores: " + totalUti.TUtilizadores();
        }
    }
}
/*
 * private TotalUtilizadores totalUlti;
  public HomeController(TotalUtilizadores total, IServicoGUID _servico) 
        {
            this.servico = _servico;
            totalUlti = total;
        }
        public IActionResult Index()
        {
            ViewBag.Mensagem = "Total de utilizadores: " + totalUlti.TUtilizadores();   
            ViewBag.Mensagem = "Usar a dependencia dos serviços";
            ViewBag.GUID = this.servico;

            return View();
        }
*/