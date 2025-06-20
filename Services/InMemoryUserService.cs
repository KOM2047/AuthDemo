using System;
using System.Collections.Generic;
using System.Linq;
using DualDashboardAuth.Models;

namespace DualDashboardAuth.Services
{
    public class InMemoryUserService : IUserService
    {
        private static readonly List<User> _users = new()
        {
            new() { Username = "alice", Password = "P@ssword1", Role = "Admin" },
            new() { Username = "bob",   Password = "P@ssword2", Role = "User"  }
        };

        public User? Validate(string username, string password)
        {
            return _users.SingleOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                && u.Password == password);
        }
    }
}

