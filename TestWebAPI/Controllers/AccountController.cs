using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Domain.Models;
using TestWebAPI.Domain.OutputModels;
using TestWebAPI.Service.Interfaces;
using TestWebAPI.Attributes;

namespace TestWebAPI.Controllers
{
    [Route("api/user-management")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IUserService _userRepo;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IUserService userRepo, ILogger<AccountController> _logger)
        {
            _userRepo = userRepo;
            this._logger = _logger;

        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {

            var response = await _userRepo.Login(model);
            return Ok(response);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [RoleAuthentication(Role.Admin)]
        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> CreateUpdateUser(UserModel model)
        {
            var response = await _userRepo.CreateUpdateUser(model);
            return Ok(response);
        }
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("get user call");
            var response = await _userRepo.GetUsers();
            return Ok(response);
        }
        [HttpGet]
        [Route("users/{userId}")]
        public async Task<IActionResult> GetUserbyId(int userId)
        {

            var response = await _userRepo.GetUserById(userId);
            return Ok(response);
        }
        [HttpDelete]
        [Route("users/{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {

            var response = await _userRepo.DeleteUserById(userId);
            return Ok(response);
        }
    }
}
