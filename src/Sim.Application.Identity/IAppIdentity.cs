using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Application.Identity
{

    public interface IAppIdentity<TEntity> where TEntity : class 
    {
        TEntity GetById(string id);
        IEnumerable<TEntity> GetAll();
        void Unlock(string id);
    }
}
