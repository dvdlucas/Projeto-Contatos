using Contatos.DataBase;
using Contatos.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Contatos.Helper;

namespace Contatos.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }



        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.setSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public bool Remover(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na Exclusão do contato");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }


        public UsuarioModel Editar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na Atualização do contato");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.DataAtualizacao = DateTime.Now;
            usuarioDB.Perfil = usuario.Perfil;

            _bancoContext.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = ListarPorId(alterarSenhaModel.Id);

            if(usuarioDB == null) throw new System.Exception("Houve um erro na atualização da senha, usuário não encontrado");

            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new System.Exception("A senha atual não confere !!!");
            

            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual !");
            
            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();
            return usuarioDB;

        }





        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }


        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorEmailLogin(string email, string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

     
    }
}

