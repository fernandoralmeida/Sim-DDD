using System;
using System.Collections.Generic;

namespace Sim.Domain.Identity.Interface.Repository
{
    using Entities;
    public interface IUserRepository : IDisposable
    {
        User GetById(string id);
        IEnumerable<User> GetAll();
        void Unlock (string id);
    }
}
