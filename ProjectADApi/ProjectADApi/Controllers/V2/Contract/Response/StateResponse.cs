using Api.Database.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
//using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    [JsonObject(IsReference = true)]
    public class StateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public ICollection<Lga> LocalGovernment { get; set; } 

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented,new JsonSerializerSettings() { PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects });
        //}
    }
}
