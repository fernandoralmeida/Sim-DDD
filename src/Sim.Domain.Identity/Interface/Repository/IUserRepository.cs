﻿using System;
using System.Collections.Generic;

namespace Sim.Domain.Identity.Interface.Repository
{
    using Entities;
    public interface IUserRepository : IDisposable
    {
        Usuario GetById(string id);
        IEnumerable<Usuario> GetAll();
        void Unlock (string id);
    }
}
