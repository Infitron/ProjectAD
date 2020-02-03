using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Artisan
    {
        public Artisan()
        {
            Booking = new HashSet<Booking>();
            Complainant = new HashSet<Complainant>();
            Gallary = new HashSet<Gallary>();
            PaymentHistory = new HashSet<PaymentHistory>();
            Quote = new HashSet<Quote>();
            Rating = new HashSet<Rating>();
            Services = new HashSet<Services>();
        }

        public string EmailAddress { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaLocation { get; set; }
        public string IdcardNo { get; set; }
        public string PicturePath { get; set; }
        public string Address { get; set; }
        public int ArtisanCategoryId { get; set; }
        public string State { get; set; }
        public string AboutMe { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ArtisanCategories ArtisanCategory { get; set; }
        public virtual ArtisanBankDetails ArtisanBankDetails { get; set; }
        public virtual ArtisanDashboard ArtisanDashboard { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Complainant> Complainant { get; set; }
        public virtual ICollection<Gallary> Gallary { get; set; }
        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
        public virtual ICollection<Quote> Quote { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<Services> Services { get; set; }
    }
}
