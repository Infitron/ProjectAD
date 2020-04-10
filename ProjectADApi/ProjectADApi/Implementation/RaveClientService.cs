using ProjectADApi.ApiConfig;
using ProjectADApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectADApi.Implementation
{
    public class RaveClientService : IRaveClient
    {
        readonly HttpClient raveClient;        
        public HttpClient RaveClient => raveClient;
        readonly FlutterRaveConf _flutterRaveConf;


        public RaveClientService(HttpClient httpClient, FlutterRaveConf flutterRaveConf)
        {
            _flutterRaveConf = flutterRaveConf;
            raveClient = httpClient;
            raveClient.BaseAddress = new Uri(_flutterRaveConf.InitiatPaymentUrl);
           
        }       

        public Task<HttpResponseMessage> SendRaveRequest(HttpRequestMessage requestMessage)
        {
            return RaveClient.SendAsync(requestMessage);
        }
    }
}
