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
    public class NINVerification : IVerificationManager
    {
        readonly GenericVerifyMeRequest _request;

        public NINVerification(GenericVerifyMeRequest request) => _request = request;



        public async Task<object> Verify()
        {
            HttpResponseMessage response = null;
            GenericVerifyMeResponse getResponse;

            VerifyMeConfig vefMe = new VerifyMeConfig();

            var sendRequest = new { firstname = _request.firstname, lastname = _request.lastname, dob = _request.dob };
            string stringSendRequest = JsonConvert.SerializeObject(sendRequest);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{vefMe.BaseUrl}{vefMe.NationalIdentiyNumberEndpoint}{_request.WhatToVerify}"),
                Content = new StringContent(stringSendRequest, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("Authorization", $"Bearer {vefMe.ApiKey}");

            using HttpClient client = new HttpClient();
            {
                response = await client.SendAsync(request);
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", vefMe.ApiKey));
                getResponse = JsonConvert.DeserializeObject<GenericVerifyMeResponse>(await response.Content.ReadAsStringAsync());
            }



            return getResponse;
        }
    }
}
