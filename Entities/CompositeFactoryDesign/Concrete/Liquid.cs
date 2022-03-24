using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CompositeFactoryDesign.Concrete
{
    public class Liquid : IConsumable,IItem
    {
        private string type;
        public string ConsumableType { get => type; set => type="Liquid"; }
        public Guid Id { get; set; }
        private string name;
        private int itemCount;
        public string ItemName { get => name; set=>name=value; }
        public int Quantity { get=>itemCount; set=>itemCount=value; }

        public Liquid(string name,int quantity)
        {
            ItemName = name;
            Quantity = quantity;
            ConsumableType = "Liquid";
        }
    }
}
