using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Response
{
    public class ArticleResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string ArticleBody { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime DateApproved { get; set; }
        public DateTime CreatedDate { get; set; }        
    }
}
