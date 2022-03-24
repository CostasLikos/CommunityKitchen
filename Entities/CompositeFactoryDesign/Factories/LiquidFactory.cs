using Entities.CompositeFactoryDesign.Concrete;
using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CompositeFactoryDesign.Factories
{
    public class LiquidFactory : IConsumableFactory
    {
        public override IConsumable CreateConsumable(string name,int quantity)
        {
            return new Liquid(name,quantity);
        }

        
    }
}
