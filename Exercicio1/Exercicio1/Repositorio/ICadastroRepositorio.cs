using Exercicio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio1.Repositorio
{
    public interface ICadastroRepositorio
    {
        CadastroModel ListarPorId(int id);
        List<CadastroModel> BuscarTodos();
        CadastroModel Adicionar(CadastroModel contato);
        CadastroModel Atualizar(CadastroModel contato);

        bool Apagar(int id);
    }
}
