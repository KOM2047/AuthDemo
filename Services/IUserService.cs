using DualDashboardAuth.Models;

namespace DualDashboardAuth.Services
{
    /// <summary>
    /// Defines custom user-validation logic.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Returns a User if credentials match, otherwise null.
        /// </summary>
        User? Validate(string username, string password);
    }
}
