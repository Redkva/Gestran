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
        void Edit(TEntity entity); 
        IEnumerable<TEntity> ListEntitys();
        void Delete(TEntity entity);
    }
}
