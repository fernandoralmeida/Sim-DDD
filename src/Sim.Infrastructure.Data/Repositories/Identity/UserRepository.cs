
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Infrastructure.Data.Repositories.Identity
{
    using Context;
    using Sim.Infrastructure.Identity.Entity;
    using Sim.Infrastructure.Identity.Interface;

    public class UserRepository : IUserRepository
    {

        protected IdentityContext _db;

        public UserRepository(IdentityContext _dbcontext)
        {
            _db = _dbcontext;
        }
        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _db.Usuarios.ToList();
        }
        
        public Usuario GetById(string id)
        {
            return _db.Usuarios.Find(id);
        }

        public void Unlock(string id)
        {
            _db.Usuarios.Find(id).LockoutEnabled = false;
            _db.SaveChanges();
        }
    }
}
