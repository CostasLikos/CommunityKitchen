using Entities.AbstratctEntitities;
using Entities.IdentityModel;
using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Event : EventObserver,IAttributes
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public Event(DateTime date):base(date)
        {
        }
    }
}
