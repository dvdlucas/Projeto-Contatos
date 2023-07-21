using Contatos.Models;

namespace Contatos.Repository
{
    public class IContatoRepository
    {
        public interface IContatoRespository
        {
            ContatoModel ListaPorId(int id);

            List<ContatoModel> BuscarTodos();
            ContatoModel Adicionar(ContatoModel contato);

            ContatoModel Editar(ContatoModel contato);

            bool Remover(int id);
        }

    }
}
