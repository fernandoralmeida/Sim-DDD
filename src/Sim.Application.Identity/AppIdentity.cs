using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Application.Identity
{
    using Sim.Infrastructure.Identity.Entity;
    using Sim.Infrastructure.Identity.Interface;
    public class AppIdentity<TEntity> : IDisposable, IUserRepository where TEntity : class
    {
        private readonly IUserRepository _userRepository;

        public AppIdentity(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _userRepository.GetAll().AsEnumerable();
        }

        public Usuario GetById(string id)
        {
            return _userRepository.GetById(id);
        }

        public void Unlock(string id)
        {
            _userRepository.Unlock(id);
        }
    }
}
