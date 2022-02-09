using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryWebApiDataAccess.IRepository;
using RepositoryWebApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_WebApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "UserDoc")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfwork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }
        /// <summary>
        /// check User and Password
        /// </summary>
        /// <param name="authenticateViewMmodel"></param>
        /// <returns></returns>
        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody] AuthenticateViewModel authenticateViewMmodel)
        {
            var user = _unitOfwork.user.Authenticate(authenticateViewMmodel.UserName, authenticateViewMmodel.Password);
            if (user == null)
                return BadRequest("Wrong User and password");
            return Ok(user);
        }

        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var isuniqueUser = _unitOfwork.user.IsUniqueUser(user.UserName);
                if (!isuniqueUser)
                    return BadRequest("UserName must be unique");
                var user1 = _unitOfwork.user.Register(user.UserName, user.Password);
                if (user1 == null)
                    return BadRequest();
            }
            return Ok();
        }
    }
}
