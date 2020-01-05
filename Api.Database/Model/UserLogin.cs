using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class UserLogin
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public string RoleId { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
