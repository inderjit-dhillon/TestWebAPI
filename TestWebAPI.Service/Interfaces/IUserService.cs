using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Domain.Models;
using TestWebAPI.Domain.OutputModels;

namespace TestWebAPI.Service.Interfaces
{
    public interface IUserService
    {
        Task<ResponseModel> Login(LoginModel model);
        Task<ResponseModel> CreateUpdateUser(UserModel model);
        Task<ResponseModel> GetUsers();
        Task<ResponseModel> GetUserById(int userId);
        Task<ResponseModel> DeleteUserById(int userId);
    }
}
