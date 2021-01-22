using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe.Request
{
    class AddressVerificationRequest
    {
        public string street { get; set; }
        public string lga { get; set; }
        public string state { get; set; }
        public string landmark { get; set; }
        public Applicant applicant { get; set; }


        public class Applicant
        {
            public string idType { get; set; }
            public string idNumber { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string phone { get; set; }
            public string dob { get; set; }
        }

    }
}
