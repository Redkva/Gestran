using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorio
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        TEntity GetEntity(int Id);
        IEnumerable<TEntity> ListEntitys();
        void Delete(int Id);
    }
}
