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
        public RepositorioFornecedor(RepositorioBase dbContext) : base(dbContext) { }


    }
}
