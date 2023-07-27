using Contatos.Models;

namespace Contatos.Repository
{
 
        public interface IContatoRepository
        {
            ContatoModel ListarPorId(int id);

            List<ContatoModel> BuscarTodos();
            ContatoModel Adicionar(ContatoModel contato);

            ContatoModel Editar(ContatoModel contato);

            bool Remover(int id);
        }

    }

