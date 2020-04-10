using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectADApi.Contract.V1.Request
{
    public class ArticleRequest
    {
        [Required(ErrorMessage = "Article title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please provide a user id")]        
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "Body of article is required")]        
        public string ArticleBody { get; set; }       

              
    }
}
