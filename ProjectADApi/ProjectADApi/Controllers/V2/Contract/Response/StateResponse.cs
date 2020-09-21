using Api.Database.Core;
using Api.Database.Data;
using Api.Database.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
//using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
   // [JsonObject(IsReference = true)]
    public class StateResponse
    {
        //private projectadContext _projectadContext = new projectadContext();
        private bluechub_ProjectADContext _projectadContext = new bluechub_ProjectADContext();
        IRepository<Lga> _lgaRepository;

        public StateResponse () => _lgaRepository = new Api.Database.Implementation.Repository<Lga>(_projectadContext);

        public int Id { get; set; }
        public string Name { get; set; }
       
        public List<Lga> LocalGovernment => _lgaRepository.GetByAsync(x => x.StateId.Equals(Id)).ToList(); 

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented,new JsonSerializerSettings() { PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects });
        //}
    }
}
