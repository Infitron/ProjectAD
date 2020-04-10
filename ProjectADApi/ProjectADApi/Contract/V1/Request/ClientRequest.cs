using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.Request
{
    public class ClientRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdcardNo { get; set; }
        public string PicturePath { get; set; }
        public string Address { get; set; }
        public string State { get; set; }

        //public virtual ICollection<Booking> Booking { get; set; }
        //public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
        //public virtual ICollection<Projects> Projects { get; set; }
        //public virtual ICollection<Rating> Rating { get; set; }
    }
}
