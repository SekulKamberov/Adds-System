namespace AddsSystem.Models.EntityModels
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using System.Security.Claims;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser  // This is Application User class.I've changed the name to User and install nuget 
    {
        // This is ApplicationUser class. I've changed the name to User and install nuget:  Microsoft.AspNet.Identity.EntityFramework
        public async System.Threading.Tasks.Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] UserPhoto { get; set; }

        public string UserInfo { get; set; }

        public virtual UserPost UserPost { get; set; }

        public virtual ICollection<UserPost> UserPosts { get; set; }
    }
}
