using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAL
{
    public class Repositorio<TEntity> : DbContext, IRepositorio<TEntity> where TEntity : class, new()
    {
        DbContext db;
        DbSet<TEntity> dbSet;

        public Repositorio(DbContext dbContext)
        {
            db = dbContext;
            dbSet = db.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($" [REPOSITORIO LAYER] Create() > {ex.Message} ");
            }
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(TEntity entity)
        {
            try
            {
                dbSet.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($" [REPOSITORIO LAYER] Edit() > {ex.Message} ");
            }
        }
         

        public IEnumerable<TEntity> ListEntitys()
        {
            try
            {
                return dbSet.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($" [REPOSITORIO LAYER] ListEntitys() > {ex.Message} ");
            }
        }
    }
}
