using Entities.CompositeFactoryDesign.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CompositeFactoryDesign.Factories
{
    public class SolidFactory : IConsumableFactory
    {
        public override IConsumable CreateConsumable(string name, int quantity)
        {
            return new Solid();
        }

        
    }
}
