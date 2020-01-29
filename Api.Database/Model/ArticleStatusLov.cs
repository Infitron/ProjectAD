using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class ArticleStatusLov
    {
        public ArticleStatusLov()
        {
            Article = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}
