using Api.VerifyMe.Core;
using Api.VerifyMe.Request;
using Api.VerifyMe.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.VerifyMe.Implementation
{
    public class DriverLicenseVerification : IVerificationManager
    {
        private GenericVerifyMeRequest _request;
        public DriverLicenseVerification(GenericVerifyMeRequest request) => _request = request;


        public async Task<object> Verify()
        {
            HttpResponseMessage response;
            GenericVerifyMeResponse getResponse;

            VerifyMeConfig vefMe = new VerifyMeConfig();
            {
                var sendRequest = new {_request.firstname,  _request.lastname,  _request.dob };
                string stringSendRequest = JsonConvert.SerializeObject(sendRequest);

                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{vefMe.BaseUrl}{vefMe.DriverLicenseEndpoint}{_request.WhatToVerify}"),
                  
                    Content = new StringContent(stringSendRequest, Encoding.UTF8, "application/json")
                };
                request.Headers.Add("Authorization", $"Bearer {vefMe.ApiKey}");

                using HttpClient client = new HttpClient();                
                response = await client.SendAsync(request);
                getResponse = JsonConvert.DeserializeObject<GenericVerifyMeResponse>(await response.Content.ReadAsStringAsync());
                //}

            }

            return getResponse;
        }


    }
}
