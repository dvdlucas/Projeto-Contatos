using Contatos.Models;

namespace Contatos.Repository
{
    public class IContatoRepository
    {
        public interface IContatoRespository
        {
            List<ContatoModel> BuscarTodos();
            ContatoModel Adicionar(ContatoModel contato);
        }

    }
}
