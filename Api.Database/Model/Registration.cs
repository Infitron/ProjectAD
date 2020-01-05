using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Registration
    {
        public Registration()
        {
            Booking = new HashSet<Booking>();
            Projects = new HashSet<Projects>();
            Rating = new HashSet<Rating>();
        }

        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long UserType { get; set; }
        public string FullAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaLocation { get; set; }
        public string IdcardNo { get; set; }
        public byte[] Picture { get; set; }
        public string Address { get; set; }
        public long ArtisanCategoryId { get; set; }
        public string State { get; set; }

        public virtual ArtisanCategories ArtisanCategory { get; set; }
        public virtual UserLogin EmailAddressNavigation { get; set; }
        public virtual UserRole UserTypeNavigation { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
