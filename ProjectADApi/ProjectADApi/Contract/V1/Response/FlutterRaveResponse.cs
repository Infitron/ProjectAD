using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Response
{
    public class FlutterRaveResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }


        public class Data
        {
            public string suggested_auth { get; set; }
        }
    }
}
