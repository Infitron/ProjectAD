using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectADApi.Contract.V1.Request
{
    public class ArticleRequest
    {
        [Required(ErrorMessage = "Article title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "User email_user id required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        
        [Required(ErrorMessage = "Body of article is required")]        
        public string ArticleBody { get; set; }       

              
    }
}
