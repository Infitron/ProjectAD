using Api.VerifyMe.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.VerifyMe.Implementation
{
    public class AddressVerification : IVerificationManager
    {
        public string _address;
        public AddressVerification(string Address) { _address = Address; }

        public async Task<HttpResponseMessage> Verify()
        { 
            HttpResponseMessage response = null;

            using (VerifyMeConfig vefMe = new VerifyMeConfig())
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{vefMe.BaseUrl}{vefMe.AddressEndpoint}"),
                    Content = new StringContent("")
                };               

                using (HttpClient client = new HttpClient())
                {
                    response = await client.SendAsync(request);
                }   

            }

            return response;
        }
    }
}
