using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Artisan
    {
        public Artisan()
        {
            Booking = new HashSet<Booking>();
            PaymentHistory = new HashSet<PaymentHistory>();
            Projects = new HashSet<Projects>();
            Rating = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaLocation { get; set; }
        public string IdcardNo { get; set; }
        public string PicturePath { get; set; }
        public string Address { get; set; }
        public int ArtisanCategoryId { get; set; }
        public string State { get; set; }

        public virtual ArtisanCategories ArtisanCategory { get; set; }
        public virtual ArtisanBankDetails ArtisanBankDetails { get; set; }
        public virtual ArtisanDashboard ArtisanDashboard { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
