using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CompositeFactoryDesign.Concrete
{
    public class Solid : IConsumable
    {
        private string type;
        public string ConsumableType { get => type; set => type="Solid"; }
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }

        public Solid()
        {
            ConsumableType = "Solid";
        }
        public Solid(string name,int quantity)
        {
            ItemName = name;
            Quantity = quantity;
        }
    }
}
