using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.VerifyMe.Core
{
   public interface IVerificationManager
    {
        Task<object> Verify();
    }   
}
