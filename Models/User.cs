﻿namespace DualDashboardAuth.Models
{
    public class User
    {
        public required string Username { get; init; }
        public required string Password { get; init; }
        public required string Role { get; init; }
    }

}
