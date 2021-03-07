﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Infra.Data.Repositories.SecDE
{
    using Sim.Domain.SecDE.Interfaces.Repositories;
    using Context;
    using System.Data.Entity;

    public class RepositoryBase<TEnty> : IDisposable, IRepositoryBase<TEnty> where TEnty : class
    {
        protected DBContext_SecDE db = new DBContext_SecDE();

        public void Add(TEnty obj)
        {
            db.Set<TEnty>().Add(obj);
            db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEnty> GetAll()
        {
            return db.Set<TEnty>().ToList();
        }

        public TEnty GetById(int id)
        {
            return db.Set<TEnty>().Find(id);
        }

        public void Remove(TEnty obj)
        {
            db.Set<TEnty>().Remove(obj);
            db.SaveChanges();
        }

        public void Update(TEnty obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}