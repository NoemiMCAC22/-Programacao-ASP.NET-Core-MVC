using Exercicio1.Data;
using Exercicio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio1.Repositorio
{
    public class CadastroRepositorio : ICadastroRepositorio
    {
        private readonly BancoContext _bancoContext;
        public CadastroRepositorio(BancoContext bancoContext) 
        { 
            _bancoContext= bancoContext;
        }

        public CadastroModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
        public List<CadastroModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public CadastroModel Adicionar(CadastroModel contato)
        {
            // gravar banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public CadastroModel Atualizar(CadastroModel contato)
        {
            CadastroModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Endereco = contato.Endereco;
            contatoDB.Telemovel = contato.Telemovel;

            _bancoContext.Contatos.Update(contatoDB);

            _bancoContext.SaveChanges();

            return contatoDB;
            
        }

        public bool Apagar(int id)
        {
            CadastroModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na deleção do contato!");

            _bancoContext.Contatos.Remove(contatoDB);

            _bancoContext.SaveChanges();

            return true;
        }
    }
}
