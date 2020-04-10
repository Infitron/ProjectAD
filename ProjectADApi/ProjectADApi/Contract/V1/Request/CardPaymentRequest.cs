using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class CardPaymentRequest
    {

        

        public string PBFPubKey { get; set; }
        public string cardno { get; set; }
        public string cvv { get; set; }
        public string expirymonth { get; set; }
        public string expiryyear { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
        public string amount { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string pin { get; set; }
        public string suggested_auth { get; set; }
        public string IP { get; set; }
        public string txRef { get; set; }
        public Meta[] meta { get; set; }
        public string redirect_url { get; set; }
        public string device_fingerprint { get; set; }


        public class Meta
        {
            public string metaname { get; set; }
            public string metavalue { get; set; }
        }
    }

    public class CardPaymentBasicRequest
    {
        public string cardno { get; set; }
        public string cvv { get; set; }
        public string expirymonth { get; set; }
        public string expiryyear { get; set; }
        public string amount { get; set; }
        public string email { get; set; }
    }

}
