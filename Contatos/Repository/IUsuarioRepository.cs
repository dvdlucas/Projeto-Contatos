using Contatos.Models;
using System.Collections.Generic;

namespace Contatos.Repository
{
    public class IUsuarioRepository
    {
        public interface IContatoRespository
        {
            UsuarioModel ListaPorId(int id);

            List<UsuarioModel> BuscarTodos();
            UsuarioModel Adicionar(UsuarioModel usuario);

            UsuarioModel Editar(UsuarioModel usuario);

            bool Remover(int id);
        }
    }
}
