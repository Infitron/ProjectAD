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
using Microsoft.IdentityModel.Tokens;
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;
using ProjectADApi.Factories;
using ProjectADApi.Factories.V1.UserFactory;

namespace ProjectADApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
      
        readonly JwtConf _jwtConf;
        readonly IRepository<UserLogin> _userRepository;
        readonly IRepository<UserRole> _userRole;
        readonly UserManager<UserLogin> _userManager;
        readonly IEmailSender _emailSender;
        private readonly projectadContext _dbContext;

        public AccountController(JwtConf jwtConf, IRepository<UserLogin> userRepository, IRepository<UserRole> userRole, UserManager<UserLogin> userManager, IEmailSender emailSender, projectadContext dbContext)
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [Route("[action]")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> AllUserLogin()
        {
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
        ///   Initiate a password reset when a user forget his/her password
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Account/ForgotPassword
        ///     
        ///     {
        ///         "Email" : "User registered email"
        ///     }
        ///     
        /// </remarks>
        ///         
        ///
        [Route("[action]")]
        [HttpPost]

        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            //if (user == null)
            //    return RedirectToAction(nameof(ForgotPasswordConfirmation));

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, "https://bluecollallarhub.com.ng");



            var message = new Message(new string[] { model.Email }, "Reset password token", callback, null);
            await _emailSender.SendEmailAsync(message);

            return Ok(new { status = HttpStatusCode.OK, message = "A reset password mail has been sent to your registered email" });
        }

        [Route("[action]")]
        [HttpPost]

        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPassword));

            var resetPassResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(new { status = HttpStatusCode.BadRequest, Message = "Password Reset Failed", Data = resetPassResult.Errors.Select(x => x.Description) });
            }

            return Ok(new { status = HttpStatusCode.OK, message = "Your Pass word has been reset" });

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
