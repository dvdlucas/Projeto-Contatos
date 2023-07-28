using Contatos.Models;

namespace Contatos.Helper
{
    public interface ISessao
    {

        void CriarSessao(UsuarioModel usuario);
        void RemoverSessao(UsuarioModel usuario);
        UsuarioModel BuscarSessao();
    }
}
