using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.AspNetCore.Mvc;

namespace ProjectADApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {       
        IRepository<UserLogin> _userLoginRepository;
        public ValuesController(IRepository<UserLogin> userLoginRepository) => _userLoginRepository = userLoginRepository;

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var issave = await _userLoginRepository.GetAllAsync();
            if (issave.Any())
            {
                return Ok(issave);
            }
            return BadRequest("no user record found");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
