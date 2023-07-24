using Contatos.DataBase;
using Contatos.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using static Contatos.Repository.IContatoRepository;

namespace Contatos.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }



        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
        
        public bool Remover(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na Exclusão do contato");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
        

        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if(contatoDB == null) throw new System.Exception("Houve um erro na Atualização do contato");
            
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Telefone = contato.Telefone;

            _bancoContext.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }


        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }


    }
}
