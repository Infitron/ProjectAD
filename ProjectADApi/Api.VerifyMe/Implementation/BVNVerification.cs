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
    public class BVNVerification : IVerificationManager
    {
        readonly GenericVerifyMeRequest _request;

        public BVNVerification(GenericVerifyMeRequest request) { _request = request; }

        public async Task<object> Verify()
        {
            HttpResponseMessage response;
            GenericVerifyMeResponse getResponse;

            VerifyMeConfig vefMe = new VerifyMeConfig();

            var sendRequest = new { _request.firstname, _request.lastname, _request.dob };
            string stringSendRequest = JsonConvert.SerializeObject(sendRequest);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{vefMe.BaseUrl}{vefMe.BankVerificationNumberEndpoint}{_request.WhatToVerify}"),
                Content = new StringContent(stringSendRequest, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("Authorization", $"Bearer {vefMe.ApiKey}");

            using HttpClient client = new HttpClient();
            response = await client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            getResponse = JsonConvert.DeserializeObject<GenericVerifyMeResponse>(content);




            return getResponse;
        }
    }
}
