using Entities.IEntities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IdentityModel
{
    public class ApplicationUser : IdentityUser, IWatcher<Event>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        //Observer Method
        public void Update(Event observer)
        {
            throw new NotImplementedException();
        }
        //Additional Properties to IdentityUser
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //Method to get FullName
        public string FullName => FirstName + " " + LastName;
        //Navigational Properties
        public List<Story> Stories { get; set; }    
    }
}
