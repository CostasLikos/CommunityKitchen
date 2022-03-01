using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public List<Item> Items { get; set; }
        public Guid ModeratorId { get; set; }
        [Required]
        public Moderator Moderator { get; set; }
    }
}
