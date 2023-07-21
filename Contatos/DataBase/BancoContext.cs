using System;
using Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Contatos.DataBase
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) :base(options)
        { 

        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
