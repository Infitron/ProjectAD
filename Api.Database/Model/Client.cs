using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Client
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PicturePath { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Code { get; set; }
        public string RefererCode { get; set; }
    }
}
