using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserLogin = new HashSet<UserLogin>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserLogin> UserLogin { get; set; }
    }
}
