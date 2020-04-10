using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.ApiConfig
{
    public class FlutterRaveConf
    {
        public string SecretKey { get; set; }
        public string PublicKey { get; set; }
        public string EncryptionKey { get; set; }
        public string InitiatPaymentUrl { get; set; }
        public string EncrytionAlgorithm { get; set; }

    }
}
