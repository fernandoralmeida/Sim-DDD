using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Application.Identity
{
    using Sim.Infrastructure.Identity.Entity;
    using Sim.Infrastructure.Identity.Interface;
    public class AppIdentity<TEntity> : IDisposable, IAppIdentity<TEntity> where TEntity : class
    {
        private readonly IUserRepository<TEntity> _userRepository;

        public AppIdentity(IUserRepository<TEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Dispose()
        {        }

        public IEnumerable<TEntity> GetAll()
        {
            return _userRepository.GetAll();
        }

        public TEntity GetById(string id)
        {
            return _userRepository.GetById(id);
        }

        public void Unlock(string id)
        {
            _userRepository.Unlock(id);
        }
    }
}
