using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe.Response
{
    class GenericVerifyMeResponse
    {
        public string status { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string bvn { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string birthdate { get; set; }
        public string nationality { get; set; }
        public string photo { get; set; }
        public Fieldmatches fieldMatches { get; set; }
    }
    public class Fieldmatches
    {
        public bool lastname { get; set; }
    }

}
