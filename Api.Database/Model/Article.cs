using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public string ArticleBody { get; set; }
        public int ApprovalStatusId { get; set; }
        public DateTime DateApproved { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Lov ApprovalStatus { get; set; }
        public virtual UserLogin User { get; set; }
    }
}
