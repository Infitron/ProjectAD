using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;
using ProjectADApi.Factories;
using ProjectADApi.Factories.V1.UserFactory;

namespace ProjectADApi.Controllers.V2
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly JwtConf _jwtConf;
        readonly IRepository<UserLogin> _userRepository;
        IRepository<UserRole> _userRole;
        UserManager<UserLogin> _userManager;

        public AccountController(JwtConf jwtConf, IRepository<UserLogin> userRepository, IRepository<UserRole> userRole, UserManager<UserLogin> userManager)
        {
            _jwtConf = jwtConf;
            _userRole = userRole;
            _userManager = userManager;
            _userRepository = userRepository;

        }

        // GET: api/Account
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        /// <summary> Logs in a user. </summary>
        /// 
        /// <remarks> 
        ///  Sample Request: 
        ///     POST api/v1/Login
        ///       {
        ///          "Username" : "segun@bluecollar.com",
        ///          "Password" :  "password"
        ///       }
        /// sample Responsw:
        ///      { 
        ///        "Success" : true,
        ///        "Token" : "token string",
        ///        "ErrorMessage" : "reason for a failed login",
        ///        "UserId" : "user uniques id",
        ///        "UserRole" : "the user role"
        ///      }
        /// </remarks>
        /// 
        // POST: api/Account/5
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new CreateUserResponse { Success = false, ErrorMessage = "username/password validation failed" });
            }

            UserLogin userExist = await _userManager.FindByEmailAsync(model.username);

            if (userExist == null)
            {
                return NotFound(new CreateUserResponse2 { ErrorMessage = new[] { "User does not exist" }, Success = false });
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(userExist, model.password);

            if (!userHasValidPassword)
            {
                return NotFound(new CreateUserResponse2 { ErrorMessage = new[] { "User does not exist" }, Success = false });
            }

            UserRole role = await _userRole.GetByIdAsync(userExist.RoleId);
            CreateUserRequest userDetails = new CreateUserRequest { EmailAddress = userExist.Email };
            CreateUserResponse2 userResponse = new CreateUserResponse2 { Success = true, UserId = userExist.Id, UserRole = role.RoleName };

            return Ok(userResponse = GenerateAuthenticationToken(userDetails, userResponse));
        }

        // POST: api/Account
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest model)
        {
            var getRoleName = await _userRole.GetByIdAsync(model.RoleId);

            if (getRoleName == null)
            {
                return NotFound(new CreateUserResponse2 { Success = false, ErrorMessage = new[] { "We could not find the role entered" } });
            }

            AppUsers appUsers = (AppUsers)Enum.Parse(typeof(AppUsers), getRoleName.RoleName);
            var userCreator = await new UserCreator2(_userManager).ExecuteCreation(appUsers, model).CreateUser(model);

            if (!userCreator.Success)
            {
                return BadRequest(userCreator);
            }

            userCreator = GenerateAuthenticationToken(model, userCreator);
            return Ok(userCreator);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("[action]")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> AllUserLogin()
        {
            var allUser = await _userRepository.GetAllAsync();

            if (allUser.Any())
            {
                return Ok(allUser.OrderBy(x => x.Id));
            }
            return NotFound();
        }

        // PUT: api/Account/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        private CreateUserResponse2 GenerateAuthenticationToken(CreateUserRequest model, CreateUserResponse2 thisUser)
        {
            var tokenHandle = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_jwtConf.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(type:JwtRegisteredClaimNames.Sub, value: model.EmailAddress),
                new Claim(type:JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                new Claim(type: JwtRegisteredClaimNames.Email, value: model.EmailAddress),
                new Claim(type: "id", value: thisUser.UserId.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandle.CreateToken(tokenDescriptor);
            thisUser.Token = tokenHandle.WriteToken(token);

            return thisUser;
        }
    }
}
