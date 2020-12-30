using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Database.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectADApi.ApiConfig;
using ProjectADApi.Controllers.V2.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectADApi.Controllers.V2
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpgradeController : ControllerBase
    {

        readonly bluechub_ProjectADContext _dbContext;
        readonly AppVariable _appVariable;
        readonly IMapper _mapper;

        public UpgradeController(bluechub_ProjectADContext dbContext, AppVariable appVariable, IMapper mapper)
        {
            _dbContext = dbContext;
            _appVariable = appVariable;
            _mapper = mapper;
        }


        // GET: api/<UpgradeController>
        [HttpGet(ApiRoute.Upgrade.GetAll)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UpgradeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UpgradeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UpgradeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UpgradeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
