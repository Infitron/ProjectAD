using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }

        public virtual UserRole Role { get; set; }
    }
}
