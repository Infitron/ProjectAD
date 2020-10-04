using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Database.Core;
using EncryptionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.V1;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;
using ProjectADApi.Core;
using ProjectADApi.Implementation;
using EncryptionService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PaymentController : ControllerBase
    {
        readonly FlutterRaveConf _flutterRaveConf;
        readonly IPaymentDataEncryption _ravePaymentDataEncryption;
        readonly IRaveClient _raveClientService;

        public PaymentController(FlutterRaveConf flutterRaveConf, IPaymentDataEncryption ravePaymentDataEncryption, IRaveClient raveClientService)
        {
            _flutterRaveConf = flutterRaveConf;
            _ravePaymentDataEncryption = ravePaymentDataEncryption;
            _raveClientService = raveClientService;
        }

        // POST: api/Payment
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost(ApiRoute.Payment.InitCardPay)]
        public async Task<IActionResult> InitialCardPayment([FromBody]CardPaymentBasicRequest model, int userId)
        {
            string dataToEncrypt = JsonConvert.SerializeObject(model);

            string encryptdate = AES.Encrypt(dataToEncrypt, _flutterRaveConf.EncryptionKey);
            string encrytedData = AES.Decrypt(encryptdate, _flutterRaveConf.EncryptionKey);

            CardPaymentRequest initPayment = new CardPaymentRequest
            {
                PBFPubKey = _flutterRaveConf.PublicKey,
                cardno = model.cardno,
                cvv = model.cvv,
                amount = model.amount,
                expirymonth = model.expirymonth

            };
            string serializeCardPayment = JsonConvert.SerializeObject(model);
            string encryptCardDetail = _ravePaymentDataEncryption.EncryptData(_flutterRaveConf.EncryptionKey, serializeCardPayment);

            var initCardTransaction = new { PBFPubKey = _flutterRaveConf.PublicKey, client = encryptCardDetail, alg = _flutterRaveConf.EncrytionAlgorithm };

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(initCardTransaction), Encoding.UTF8, "application/json"),
                RequestUri = new Uri(_flutterRaveConf.InitiatPaymentUrl)
            };

            HttpResponseMessage response = await _raveClientService.SendRaveRequest(request);

            if (response.IsSuccessStatusCode)
            {
                string responseResultContent = await response.Content.ReadAsStringAsync();
                FlutterRaveResponse raveResponse = JsonConvert.DeserializeObject<FlutterRaveResponse>(responseResultContent);

                return Ok(new { status = HttpStatusCode.OK, Message = raveResponse });
            }

            string responseResultContentF = await response.Content.ReadAsStringAsync();
            FlutterRaveResponse raveResponseF = JsonConvert.DeserializeObject<FlutterRaveResponse>(responseResultContentF);

            return BadRequest(new { status = HttpStatusCode.BadRequest, Message = raveResponseF });
        }

        // GET: api/Payment/5
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost(ApiRoute.Payment.AuthenticatePin)]
        public async Task<IActionResult> ConfirmPaymentWithOTP([FromBody]CardPaymentRequest model)
        {
            string serializeCardPayment = JsonConvert.SerializeObject(model);
            string encryptCardDetail = _ravePaymentDataEncryption.EncryptData(_flutterRaveConf.EncryptionKey, serializeCardPayment);

            var initCardTransaction = new { PBFPubKey = _flutterRaveConf.PublicKey, Client = encryptCardDetail, alg = _flutterRaveConf.EncrytionAlgorithm };

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(initCardTransaction), Encoding.UTF8, "application/json"),
                RequestUri = new Uri(_flutterRaveConf.InitiatPaymentUrl)
            };

            HttpResponseMessage response = await _raveClientService.SendRaveRequest(request);

            if (response.IsSuccessStatusCode)
            {
                string responseResultContent = await response.Content.ReadAsStringAsync();
                FlutterRaveResponse raveResponse = JsonConvert.DeserializeObject<FlutterRaveResponse>(responseResultContent);

                return Ok(new { status = HttpStatusCode.OK, Message = raveResponse });
            }

            string responseResultContentF = await response.Content.ReadAsStringAsync();
            FlutterRaveResponse raveResponseF = JsonConvert.DeserializeObject<FlutterRaveResponse>(responseResultContentF);

            return BadRequest(new { status = HttpStatusCode.BadRequest, Message = raveResponseF });
        }

        //// POST: api/Payment
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Payment/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
