using System;
using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common
{
    public interface IUser
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        bool EmailConfirmed { get; set; }
        string PasswordHash { get; set; }
        string SecurityStamp { get; set; }
        string PhoneNumber { get; set; }
        bool PhoneNumberConfirmed { get; set; }
        bool TwoFactorEnabled { get; set; }
        Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        bool LockoutEnabled { get; set; }
        int AccessFailedCount { get; set; }
        string UserName { get; set; }
    }
}
