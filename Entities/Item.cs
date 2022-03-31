using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }

        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal")]
        public decimal Price { get; set; }
        public List<Inventory> Inventories { get; set; }

    }
}
