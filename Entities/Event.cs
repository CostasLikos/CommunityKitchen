using Entities.AbstratctEntitities;
using Entities.IdentityModel;
using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Event :IAttributes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        //IAttributes Implementation
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public DateTime EventDate { get; set; }

        //Observers
        public List<ApplicationUser> Users { get; set; }
        

    }
}
