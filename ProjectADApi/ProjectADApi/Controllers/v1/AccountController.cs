using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.V1;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;
using ProjectADApi.Factories.V1.UserFactory;

namespace ProjectADApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly JwtConf _jwtConf;
        IRepository<UserLogin> _userRepository;
        IRepository<UserRole> _userRole;



        public AccountController(JwtConf jwtConf, IRepository<UserLogin> userRepository, IRepository<UserRole> userRole) { _jwtConf = jwtConf; _userRepository = userRepository; _userRole = userRole;  }


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
        
        // GET: api/Account/5
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new CreateUserResponse { Success = false, ErrorMessage = "username/password validation failed" });
            }

            UserLogin userExist = await _userRepository.GetAllAsync().ContinueWith(  (result) => {
                return result.Result.SingleOrDefault(x => x.EmailAddress.Equals(model.username) && x.Password.Equals(model.password));
            });
            

            if(userExist == null)
            {
                return NotFound();
            }
            UserRole role = await _userRole.GetByIdAsync(userExist.RoleId);
            CreateUserRequest userDetails = new CreateUserRequest { EmailAddress = userExist.EmailAddress};
            CreateUserResponse userResponse = new CreateUserResponse { Success = true, UserId = userExist.Id, UserRole = role.RoleName };

            return Ok(userResponse = GenerateAuthenticationToken(userDetails, userResponse));           
        }

        // POST: api/Account
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest model)
        {
            var getRoleName = await _userRole.GetByIdAsync(model.RoleId);

            if(getRoleName == null)
            {
                return NotFound(new CreateUserResponse { Success = false, ErrorMessage = "We could not find the role entered" });
            }

            AppUsers appUsers = (AppUsers)Enum.Parse(typeof(AppUsers), getRoleName.RoleName);
            var userCreator = await new UserCreator().ExecuteCreation(appUsers, model).CreateUser(model);           

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

            if(allUser.Any())
            {
                return Ok(allUser.OrderBy(x => x.Id));
            }            
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userExist = await _userRepository.GetAllAsync().ContinueWith( (result) => {
                UserLogin thisUser = result.Result.SingleOrDefault(x => x.EmailAddress.Equals(model.Email));
                return thisUser;
            });

            if (userExist == null)
                return NotFound(new { Message = "This user does not exist" });

            userExist.Password = model.NewPassword;
             await _userRepository.UpdateAsync(userExist);

            return Ok(new CreateUserResponse { Success = true });
        }


        private CreateUserResponse GenerateAuthenticationToken(CreateUserRequest model, CreateUserResponse thisUser)
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








