using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Infrastructure.Identity.Interface
{
    using Entity;
    public interface IUserRepository : IDisposable
    {
        Usuario GetById(string id);
        IEnumerable<Usuario> GetAll();
        void Unlock(string id);

    }
}
