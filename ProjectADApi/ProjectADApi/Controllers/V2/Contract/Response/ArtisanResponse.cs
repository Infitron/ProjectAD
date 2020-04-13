using Api.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Response
{
    public class ArtisanResponse
    {
        
        public int Id { get; set; }
        /// <summary>
        ///  This identity the artisan from the userlogin table
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        ///    This identity the artisan from the userlogin table
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        ///    
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IdcardNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PicturePath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ArtisanCategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AreaLocationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AboutMe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LocationResponse AreaLocation { get; set; }

        /// <summary>
        ///
       /// </summary>
         public ArtisanCategoryResponse ArtisanCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<BookingResponse> Booking { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public List<GallaryResponse> Gallary { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
       public List<PaymentHistoryResponse> PaymentHistory { get; set; }
        /// <summary>
        ///  The list  of all the project the artisan has done on the platform
        /// </summary>
        public List<ProjectResponse> Projects { get; set; }
        
       /// <summary>
        ///  The service an artisan offers
        /// </summary>
        public List<ServiceResponse> Services { get; set; }
    }
}
