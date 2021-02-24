using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class VerificationRequest
    {
        public int Id { get; set; }
        public string BankAccount { get; set; }
        public string BankVerificationNumber { get; set; }
        public string Nin { get; set; }
        public string PassportNumber { get; set; }
        public string DriverLicense { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Lga { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string ApplicantFirstname { get; set; }
        public string ApplicantLastname { get; set; }
        public string ApplicantDob { get; set; }
        public string ApplicantPhone { get; set; }
        public string ApplicantIdtype { get; set; }
        public string ApplicantIdnumber { get; set; }
    }
}
