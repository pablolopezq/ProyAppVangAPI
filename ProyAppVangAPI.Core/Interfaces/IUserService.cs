using ProyAppVangAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyAppVangAPI.Core.Interfaces
{
    public interface IUserService
    {
        ServiceResult<User> Create(User user);

        ServiceResult<bool> Check(User user);
    }
}
