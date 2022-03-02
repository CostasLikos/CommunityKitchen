using Entities.IdentityModel;
using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Moderator : ApplicationUser, IProfileAdmin, IEventCauseLists
    {
        //Additional Properties for Moderators/Admin users
        public string FilePath { get; set; }
        public string SocialSecurityNumber { get; set; }
        //Navigational Properties
        public List<Event> Events { get; set; }
        public List<Cause> Causes { get; set; }
        public Guid? InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}
