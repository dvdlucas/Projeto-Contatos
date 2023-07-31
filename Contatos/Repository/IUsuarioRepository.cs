using Contatos.Models;
using System.Collections.Generic;

namespace Contatos.Repository
{
     

        public interface IUsuarioRepository
        {

            UsuarioModel BuscarPorLogin(string login);

           UsuarioModel BuscarPorEmailLogin(string email, string login);

        UsuarioModel ListarPorId(int id);

            List<UsuarioModel> BuscarTodos();
            UsuarioModel Adicionar(UsuarioModel usuario);

            UsuarioModel Editar(UsuarioModel usuario);

            bool Remover(int id);
        }
    }

