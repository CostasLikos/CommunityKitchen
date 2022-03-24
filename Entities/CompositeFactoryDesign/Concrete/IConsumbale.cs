using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CompositeFactoryDesign.Concrete
{
    public interface IConsumable
    {
        string ConsumableType { get; set; }
    }
}
