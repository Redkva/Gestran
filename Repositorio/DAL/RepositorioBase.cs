using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAL
{
    public class RepositorioBase : DbContext
    {
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EnderecoFornecedor> EnderecoFornecedor { get; set; }

        public RepositorioBase(DbContextOptions<RepositorioBase> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EnderecoFornecedor>().HasKey(x => new { x.IdEndereco, x.IdFornecedor });

            builder.Entity<EnderecoFornecedor>().HasOne(x => x.Fornecedor).WithMany(y => y.EnderecoFornecedor).HasForeignKey(x => x.IdFornecedor);

        }

    }
}
