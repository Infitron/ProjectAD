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
using Api.EmailService;
using Api.EmailService.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.Factories;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    [SwaggerTag("This is the version 1.1 of the Account endpoints. Forget password and reset password are delibrately left out from this version. Activating and Suspending a user have been include in the version. We advice to use the this version of the account to update the user activation and suspension")]
    public class AccountController : ControllerBase
    {

        readonly JwtConf _jwtConf;
        readonly IRepository<UserLogin> _userRepository;
        readonly IRepository<UserRole> _userRole;
        readonly UserManager<UserLogin> _userManager;
        readonly IEmailSender _emailSender;
        readonly bluechub_ProjectADContext _dbContext;

        public AccountController(JwtConf jwtConf, IRepository<UserLogin> userRepository, IRepository<UserRole> userRole, UserManager<UserLogin> userManager, IEmailSender emailSender, bluechub_ProjectADContext dbContext)
        {
            _jwtConf = jwtConf;
            _userRole = userRole;
            _userManager = userManager;
            _userRepository = userRepository;
            _emailSender = emailSender;
            _dbContext = dbContext;
        }

        // POST: api/V1/Account
        /// <summary>
        /// Use login, authenticat registered users on the plarform
        /// </summary>
        /// 
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Account/Login
        ///     
        ///     {        
        ///       "Username": "info@bluecollar.com.ng",
        ///       "Password": "@infoBlue1"
        ///     }
        ///     
        /// </remarks>
        /// 
        /// <param name="model"></param>  
        ///

        [HttpPost(ApiRoute.Account.Login)]
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
                return NotFound(new CreateUserResponse2 { ErrorMessage = new[] { "Wrong user name or password" }, Success = false });
            }

            if (!userExist.StatusId.Equals((int)AppStatus.Active))
            {
                return BadRequest(new CreateUserResponse2 { ErrorMessage = new[] { "This user has been suspended" }, Success = false });
            }


            UserRole role = await _userRole.GetByAsync(x => x.RoleId.Equals(userExist.RoleId)).FirstOrDefaultAsync();
            CreateUserRequest userDetails = new CreateUserRequest { EmailAddress = userExist.Email };
            CreateUserResponse2 userResponse = new CreateUserResponse2 { Success = true, UserId = userExist.Id, UserRole = role.RoleName };

            return Ok(userResponse = GenerateAuthenticationToken(userDetails, userResponse));
        }

        // POST: api/Account
        /// <summary>
        /// 
        /// Register a new user on the platform
        /// Password must have at least one special character,
        /// one upper case character and
        /// a digit between 0-9
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Account/Register
        ///     
        ///     {
        ///       "EmailAddress": "info@bluecollar.com.ng",
        ///       "Password": "@infoBlue1",
        ///       "CreationDate": 2020/2/10,
        ///       "RoleId": 1,
        ///       "UserName": "BlueCollarHub"
        ///     }
        ///     
        /// </remarks>
        /// 
        /// <param name="model"></param>  
        ///

        [HttpPost(ApiRoute.Account.Register)]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest model)
        {
            var getRoleName = await _userRole.GetByAsync(x => x.RoleId.Equals(model.RoleId)).FirstOrDefaultAsync();

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
            userCreator.UserRole = getRoleName.RoleName;
            return Ok(userCreator);
        }

        /// <summary>
        /// 
        /// Display all registered user/login details on the platofrm
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET api/Account/AllUserLogin
        ///     
        /// </remarks>
        /// 
        /// <response code="201">Returns all Registered users</response>
        /// <response code="204">Return no content found </response>
        ///
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [HttpGet(ApiRoute.Account.AllUser)]
        [Produces("application/json")]
        public async Task<IActionResult> AllUserLogin(int? id)
        {
            if (id != null)
            {
                var thisUser = await Task.Run(() => (from user in _dbContext.UserLogin
                                                     where user.Id == id.Value
                                                     select new
                                                     {
                                                         UserId = user.Id,
                                                         Username = user.UserName,
                                                         UserRole = user.Role.RoleName,
                                                         EmailAddress = user.Email,
                                                         DateRegisterd = user.CreationDate,
                                                         Status = user.Status.Status
                                                     }).FirstOrDefault());
                return Ok(new { status = HttpStatusCode.OK, message = thisUser });
            }
            var allUser = await Task.Run(() => (from user in _dbContext.UserLogin
                                                select new
                                                {
                                                    UserId = user.Id,
                                                    Username = user.UserName,
                                                    UserRole = user.Role.RoleName,
                                                    EmailAddress = user.Email,
                                                    DateRegisterd = user.CreationDate,
                                                    Status = user.Status.Status
                                                }).ToList());

            if (allUser.Any())
            {
                return Ok(new { status = HttpStatusCode.OK, message = allUser });
            }
            return NoContent();
        }

        /// <summary>
        /// 
        ///   Updates the login status of any user of the platform. please see sample request below to activate or deactivate a user
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Account/UpdateStatus
        ///     
        ///     {
        ///         "UserId" : 0
        ///         "StatusId" : 0
        ///     }
        ///     
        /// </remarks>
        ///         
        ///       
        [Authorize]
        [HttpPut(ApiRoute.Account.Update)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateLoginStatusRequest model)
        {
            UserLogin getUser = await _userRepository.GetByAsync(x => x.Id.Equals(model.UserId)).FirstOrDefaultAsync();

            if (getUser == null) return BadRequest(new { Status = HttpStatusCode.BadRequest, message = "No user with the id enterd exist" });

            getUser.StatusId = model.StatusId;

            getUser = await _userRepository.UpdateAsync(getUser);

            var updatedUser =
            new
            {
                UserId = getUser.Id,
                Username = getUser.UserName,
                UserRole = getUser.Role.RoleName,
                EmailAddress = getUser.Email,
                DateRegisterd = getUser.CreationDate,
                Status = getUser.Status.Status
            };

            return Ok(new { status = HttpStatusCode.OK, message = updatedUser });
        }

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
