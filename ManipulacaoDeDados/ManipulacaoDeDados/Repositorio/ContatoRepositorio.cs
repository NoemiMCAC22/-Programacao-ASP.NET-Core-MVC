using ManipulacaoDeDados.Data;
using ManipulacaoDeDados.Models;

namespace ManipulacaoDeDados.Repositorio
{

    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public ContatoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public ContatoModelo ListarPorId(int id)
        {
            return _bancoContexto.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModelo> InserirTodos()
        {
            return _bancoContexto.Contatos.ToList();
        }
        public ContatoModelo Adicionar(ContatoModelo contato)
        {
            _bancoContexto.Contatos.Add(contato);
            _bancoContexto.SaveChanges();

            return contato;
        }

        public ContatoModelo Atualizar(ContatoModelo contato)
        {
            ContatoModelo contatoBD = ListarPorId(contato.Id);

            if (contatoBD == null) throw new System.Exception("Houve um erro na atualização do contato!");

            contatoBD.nome= contato.nome;   
            contatoBD.email= contato.email;
            contatoBD.telemovel= contato.telemovel;

            _bancoContexto.Contatos.Update(contatoBD);
            _bancoContexto.SaveChanges();

            return contatoBD;
        }

        public bool Apagar(int id)
        {
            ContatoModelo contatoBD = ListarPorId(id);

            if (contatoBD == null) throw new System.Exception("Houve um erro na atualização do contato!");

            _bancoContexto.Contatos.Remove(contatoBD);
            _bancoContexto.SaveChanges();

            return true;
        }
    }
}