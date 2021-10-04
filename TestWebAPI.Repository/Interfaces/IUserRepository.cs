using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Domain.Models;
using TestWebAPI.Domain.OutputModels;

namespace TestWebAPI.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserResModel> Login(LoginModel model);
        public Task<UserResModel> GetUserById(int userId);
        public Task<int> AddUser(UserModel model);
        public Task<int> UpdateUser(UserModel model);
    }
}
