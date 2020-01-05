using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class UserRole
    {
        public UserRole()
        {
            Registration = new HashSet<Registration>();
        }

        public long RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
