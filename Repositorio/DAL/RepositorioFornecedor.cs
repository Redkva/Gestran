using Domain.Entidades;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAL
{
    public class RepositorioFornecedor : Repositorio<Fornecedor>, IRepositorioFornecedor
    {
        protected RepositorioBase db;
        public RepositorioFornecedor(RepositorioBase dbContext) : base(dbContext) { db = dbContext; }

        public Fornecedor GetFornecedor(int Id)
        {
            try
            {
                return db.Fornecedores.Where(x => x.IdFornecedor == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($" [REPOSITORIO LAYER] GetFornecedor() > {ex.Message} ");
            }
        }
    }
}
