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
    public class Story : IAttributes
    {
        public Guid StoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
