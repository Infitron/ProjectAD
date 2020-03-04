using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectADApi.Core
{
   public interface IRaveClient
    {
        HttpClient RaveClient { get; }
        Task<HttpResponseMessage> SendRaveRequest(HttpRequestMessage requestMessage);
    }
}
