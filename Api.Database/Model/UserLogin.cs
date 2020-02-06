using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Model
{
    public partial class UserLogin : IdentityUser<int>
    {
        // public string NormalizedUserName { get; set; }
        // public string Email { get; set; }
        // public string NormalizedEmail { get; set; }
        // public bool EmailConfirmed { get; set; }
        // public string PasswordHash { get; set; }
        // public string SecurityStamp { get; set; }
        // public string ConcurrencyStamp { get; set; }
        // public string PhoneNumber { get; set; }
        // public bool PhoneNumberConfirmed { get; set; }
        // public bool TwoFactorEnabled { get; set; }
        // public DateTimeOffset? LockoutEnd { get; set; }
        // public bool LockoutEnabled { get; set; }
        // public int AccessFailedCount { get; set; }
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int RoleId { get; set; }
        public override string UserName { get; set; }
        public int StatusId { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual Lov Status { get; set; }
    }
}
