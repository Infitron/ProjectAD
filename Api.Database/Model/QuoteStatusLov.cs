using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class QuoteStatusLov
    {
        public QuoteStatusLov()
        {
            Quote = new HashSet<Quote>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Quote> Quote { get; set; }
    }
}
