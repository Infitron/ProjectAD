using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Response
{
    public class CreateUserResponse2
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> ErrorMessage { get; set; }
        public int UserId { get; set; }
        public string UserRole { get; set; }
        
    }
}
