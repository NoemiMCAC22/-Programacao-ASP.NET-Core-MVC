using ManipulacaoDeDados.Models;
using ManipulacaoDeDados.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ManipulacaoDeDados.Controllers
{
    public class ContatoController1 : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController1(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModelo> contatos = _contatoRepositorio.InserirTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModelo contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModelo contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                

                return RedirectToAction("Index");
            }
            catch (System.Exception erro) 
            {
                TempData["MensagemErro"] = $"Não foi possível apagar o contato, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
             
        }

        [HttpPost]

        public IActionResult Criar(ContatoModelo contato)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato registado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o contato, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }


            [HttpPost]

            public IActionResult Alterar(ContatoModelo contato)
            {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível atualizar o contato, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }
    }
} 


