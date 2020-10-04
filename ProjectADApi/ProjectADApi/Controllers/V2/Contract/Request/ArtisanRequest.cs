using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class ArtisanRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
         [Required]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int AreaLocationId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        
        public string IdcardNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string PicturePath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int ArtisanCategoryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        
        public string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string AboutMe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RefererCode { get; set; }
    }
}
