using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Edit(TEntity entity);
        IEnumerable<TEntity> ListEntitys();
        void Delete(int Id);
    }
}
