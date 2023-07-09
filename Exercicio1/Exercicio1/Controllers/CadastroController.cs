using Exercicio1.Models;
using Exercicio1.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio1.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ICadastroRepositorio _cadastroRepositorio;
        public CadastroController(ICadastroRepositorio cadastroRepositorio) 
        { 
            _cadastroRepositorio= cadastroRepositorio;
        }
        public IActionResult Index()
        {
            List<CadastroModel> contatos = _cadastroRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            CadastroModel contato = _cadastroRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            CadastroModel contato = _cadastroRepositorio.ListarPorId(id);

            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            _cadastroRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(CadastroModel cadastro) 
        {
            if(ModelState.IsValid)
                {
                _cadastroRepositorio.Adicionar(cadastro);
                return RedirectToAction("Index");
                 }     
            return View(cadastro);
        }

        [HttpPost]
        public IActionResult Alterar(CadastroModel cadastro)
        {
            if (ModelState.IsValid)
            {
                _cadastroRepositorio.Atualizar(cadastro);
                return RedirectToAction("Index");
            }
            return View("Editar", cadastro);
        }
    }
}
