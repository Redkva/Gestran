using Domain.Entidades;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAL
{
    public class RepositorioEndereco : Repositorio<Endereco>, IRepositorioEndereco
    {
        RepositorioBase db;
        public RepositorioEndereco(RepositorioBase dbContext) : base(dbContext) { db = dbContext; }

        public List<Endereco> GetEnderecos(List<int> fornecedoresIds)
        {
            try
            {
                var retorno = db.Enderecos.Where(x => fornecedoresIds.Contains(x.IdFornecedor)).ToList();

                retorno.ForEach(e => db.Entry(e).State = EntityState.Detached);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception($" [REPOSITORIO LAYER] GetEnderecos() > {ex.Message} ");
            }
        }
    }
}
