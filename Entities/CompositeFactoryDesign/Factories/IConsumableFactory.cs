using Entities.CompositeFactoryDesign.Concrete;
using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CompositeFactoryDesign.Factories
{
    public abstract class IConsumableFactory
    {
        public abstract IConsumable CreateConsumable(string name,int quantity);
    }
}
