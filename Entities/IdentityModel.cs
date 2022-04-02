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
    public class ApplicationUser : IdentityUser, IWatcher
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationUser()
        {

        }

        //Observer Method
        public void Update(DateTime date)
        {
            Console.WriteLine("The date of an event has changed to {0}",date.ToShortDateString());
        }
        //Additional Properties to IdentityUser
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //Method to get FullName
        public string FullName => FirstName + " " + LastName;
        //Navigational Properties
        public List<Story> Stories { get; set; }
        public List<Event> Events { get; set; }
        public List<Cause> Causes { get; set; }
        public Guid? InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}
