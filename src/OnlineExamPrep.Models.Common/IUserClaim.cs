﻿namespace OnlineExamPrep.Models.Common
{
    public interface IUserClaim
    {
        int Id { get; set; }
        string UserId { get; set; }
        string ClaimType { get; set; }
        string ClaimValue { get; set; }
    }
}
