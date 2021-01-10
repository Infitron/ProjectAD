using Api.VerifyMe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe.Implementation
{
    public class DriverLicenseVerification : IVerificationManager
    {
        private string _licenceNumber;
        public DriverLicenseVerification(string DriverLicenceNumber) => _licenceNumber = DriverLicenceNumber;


        public void Verify()
        {
            throw new NotImplementedException();
        }


    }
}
