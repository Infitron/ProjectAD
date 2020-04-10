using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class Complaint
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EmailId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StatusId { get; set; }
        public DateTime DateResolved { get; set; }

        public virtual Lov Status { get; set; }
    }
}
