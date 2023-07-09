using ManipulacaoDeDados.Models;

namespace ManipulacaoDeDados.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModelo ListarPorId(int id);
        List<ContatoModelo> InserirTodos();
        ContatoModelo Adicionar(ContatoModelo contato);
        ContatoModelo Atualizar(ContatoModelo contato);
        bool Apagar (int id);
    }
}