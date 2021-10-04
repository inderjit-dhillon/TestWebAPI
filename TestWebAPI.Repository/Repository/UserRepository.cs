using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Domain.Models;
using TestWebAPI.Domain.OutputModels;
using TestWebAPI.Repository.Context;
using TestWebAPI.Repository.Interfaces;

namespace TestWebAPI.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private static Random random = new Random();

        public UserRepository(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserResModel> GetUserById(int userId)
        {
            TestDbContext context = (TestDbContext)_unitOfWork.Db;
            User userData = context.Users.FindAsync(userId).Result;
            UserResModel user = _mapper.Map<UserResModel>(userData);
            return user;
        }
        public async Task<int> AddUser(UserModel model)
        {
            TestDbContext context = (TestDbContext)_unitOfWork.Db;
            User user = _mapper.Map<User>(model);
            user.IsDelete = false;
            user.Password = RandomString(8);
            context.Users.Add(user);
            _ = await _unitOfWork.Save();
            return user.UserId;
        }
        public async Task<int> UpdateUser(UserModel model)
        {
            TestDbContext context = (TestDbContext)_unitOfWork.Db;
            User user = context.Users.FindAsync(model.UserId).Result;
            if (user != null)
            {
                user.Name = model.Name;
                user.Email = model.Email;
                user.City = model.City;
                user.Mobile = model.Mobile;
                context.Users.Update(user);
                _ = await _unitOfWork.Save();
                return user.UserId;
            }
            else
            {
                return -1;
            }

        }

        public async Task<UserResModel> Login(LoginModel model)
        {
            TestDbContext context = (TestDbContext)_unitOfWork.Db;
            User user = context.Users.Where(x => x.Email == model.UserName && x.Password == model.Password).FirstOrDefault();
            if (user != null)
            {
                return _mapper.Map<UserResModel>(user);
            }
            else
            {
                return null;
            }

        }

        #region HELPERS
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #endregion
    }
}
