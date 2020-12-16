using ProyAppVangAPI.Core.Entities;
using ProyAppVangAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyAppVangAPI.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public ServiceResult<bool> Check(User user)
        {
            var users = _userRepository.GetAll();
            return ServiceResult<bool>.SuccessResult(users.Any(u => u.Username == user.Username && u.Password == user.Password));
        }

        public ServiceResult<User> Create(User user)
        {
            return ServiceResult<User>.SuccessResult(_userRepository.Create(user));
        }
    }
}
