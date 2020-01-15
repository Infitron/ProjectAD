using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectADApi.ApiConfig;
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

        public AccountController(JwtConf jwtConf) => _jwtConf = jwtConf;

        // GET: api/Account
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        [Route("[action]")]
        [HttpGet]
        public string Login([FromBody] CreateUserRequest model)
        {
            return "value";
        }

        // POST: api/Account
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest model)
        {
            AppUsers appUsers = (AppUsers)Enum.Parse(typeof(AppUsers), model.RoleName);
            var userCreator = await new UserCreator().ExecuteCreation(appUsers, model).CreateUser(model);           

            if (!userCreator.Success)
            {
                return BadRequest(userCreator);
            }

            userCreator = GenerateAuthenticationToken(model, userCreator);
            return Ok(userCreator);
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public CreateUserResponse GenerateAuthenticationToken(CreateUserRequest model, CreateUserResponse thisUser)
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








