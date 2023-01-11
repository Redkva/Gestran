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
        TEntity GetEntity(int Id);
        IEnumerable<TEntity> ListEntitys();
        void Delete(int Id);
    }
}
