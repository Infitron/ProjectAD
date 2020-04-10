using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Response
{
    public class ArtisanResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }       
        public string IdcardNo { get; set; }
        public string PicturePath { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string State { get; set; }
        public string AboutMe { get; set; }
        public DateTime? CreatedDate { get; set; }

        public  object AreaLocation { get; set; }
        public object ArtisanCategory { get; set; }
        //public List<object> Quote { get; set; }
        //public  List<ArtisanServices> ArtisanServices { get; set; }
        //public  List<Booking> Booking { get; set; }
        //public  List<Gallary> Gallary { get; set; }
        //public  List<PaymentHistory> PaymentHistory { get; set; }
        //public  List<Projects> Projects { get; set; }
        //public  List<Rating> Rating { get; set; }
        //public  List<Services> Services { get; set; }
    }
}
