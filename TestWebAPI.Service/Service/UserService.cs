using AutoMapper;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Domain.Models;
using TestWebAPI.Domain.OutputModels;
using TestWebAPI.Domain.SPModels;
using TestWebAPI.Repository.Dapper;
using TestWebAPI.Repository.Interfaces;
using TestWebAPI.Service.Interfaces;
using TestWebAPI.Utility;

namespace TestWebAPI.Service.Service
{
    public class UserService : IUserService
    {
        private readonly SqlHandler sqlHandler;
        private readonly IMapper _mapper;
        private readonly IDapper _dapper;
        private readonly IUserRepository _userRepository;
        public UserService(SqlHandler sqlHandler, IMapper mapper, IDapper dapper, IUserRepository userRepository)
        {
            this.sqlHandler = sqlHandler;
            _mapper = mapper;
            _dapper = dapper;
            _userRepository = userRepository;
        }
        public async Task<ResponseModel> CreateUpdateUser(UserModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            int result = 0;
            if (model.IsUpdate == true)
            {
                result = await _userRepository.UpdateUser(model);
            }
            else
            {
                result = await _userRepository.AddUser(model);
            }
            if (result > 0)
            {
                responseModel.StatusCode = 200;
                responseModel.Message = "Success";
                responseModel.Response = result;
            }
            else if (result < 0)
            {
                responseModel.StatusCode = 404;
                responseModel.Message = "Invalid userId";
                responseModel.Response = null;
            }
            else
            {
                responseModel.StatusCode = 400;
                responseModel.Message = "Something went wrong";
                responseModel.Response = null;
            }
            return responseModel;
        }

        public async Task<ResponseModel> GetUserById(int userId)
        {
            ResponseModel responseModel = new ResponseModel();
            var result = await _userRepository.GetUserById(userId);
            //var param = new
            //{
            //    UserId = userId
            //};
            //var sqlQuery = new Result<SPGetUserModel>("GetUserById", param);
            //var result = await sqlHandler.ExecuteQuery(sqlQuery);
            if (result != null)
            {
                responseModel.StatusCode = 200;
                responseModel.Message = "Success";
                responseModel.Response = result;
            }
            else
            {
                responseModel.StatusCode = 404;
                responseModel.Message = "User not exists";
            }
            return responseModel;
        }

        public async Task<ResponseModel> GetUsers()
        {
            ResponseModel responseModel = new ResponseModel();
            var sqlQuery = new Results<SPGetUserModel>("GetUsers");
            var result = await sqlHandler.ExecuteQuery(sqlQuery);
            if (result != null)
            {
                responseModel.StatusCode = 200;
                responseModel.Message = "Success";
                responseModel.Response = result;
            }
            else
            {
                responseModel.StatusCode = 400;
                responseModel.Message = "Something went wrong";
            }
            return responseModel;
        }
        public async Task<ResponseModel> DeleteUserById(int userId)
        {
            ResponseModel responseModel = new ResponseModel();
            var param = new
            {
                UserId = userId
            };
            var sqlQuery = new Result<object>("DeleteUserById", param);
            var result = await sqlHandler.ExecuteQuery(sqlQuery);
            responseModel.StatusCode = 200;
            responseModel.Message = "Success";
            return responseModel;
        }

        public async Task<ResponseModel> Login(LoginModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            var result = await _userRepository.Login(model);
            if (result != null)
            {
                responseModel.StatusCode = 200;
                responseModel.Message = "Success";
                responseModel.Response = GenerateJSONWebToken(result);
            }
            else
            {
                responseModel.StatusCode = 404;
                responseModel.Message = "Invalid credentials";
            }
            return responseModel;
        }
        private string GenerateJSONWebToken(UserResModel userInfo)
        {
            if (userInfo != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.JwtKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new  Claim("UserId", string.IsNullOrEmpty(Convert.ToString(userInfo.UserId)) ? string.Empty : Convert.ToString(userInfo.UserId)),
                    new  Claim("Name", string.IsNullOrEmpty(Convert.ToString(userInfo.Name)) ? string.Empty : Convert.ToString(userInfo.Name)),
                    new  Claim("Email", (string.IsNullOrEmpty(Convert.ToString(userInfo.Email)) ? string.Empty : Convert.ToString(userInfo.Email))),
                    new  Claim("City", (string.IsNullOrEmpty(Convert.ToString(userInfo.City)) ? string.Empty : Convert.ToString(userInfo.City))),
                    new  Claim("Mobile", (string.IsNullOrEmpty(Convert.ToString(userInfo.Mobile)) ? string.Empty : Convert.ToString(userInfo.Mobile))),
                    new  Claim("RoleId", (string.IsNullOrEmpty(Convert.ToString(userInfo.RoleId)) ? string.Empty : Convert.ToString(userInfo.RoleId))),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(JwtConfig.JwtIssuer, JwtConfig.JwtIssuer,
                    claims, expires: DateTime.Now.AddMinutes(30000), signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
