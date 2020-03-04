using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class UserProfileRequest
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int AreaLocationId { get; set; }
        public string IdcardNo { get; set; }
        public string PicturePath { get; set; }
        public string Address { get; set; }
        public int ArtisanCategoryId { get; set; }
        public string State { get; set; }
        public string AboutMe { get; set; }
        public int UserId { get; set; }
    }
}
