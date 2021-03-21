using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sim.Infrastructure.Data.Repositories.SDE
{
    using Sim.Domain.SDE.Interfaces.Repositories;
    using Context;

    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DbContextSDE _db;
        
        public RepositoryBase(DbContextSDE dbcontext)
        {
            _db = dbcontext;
        }

        public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
