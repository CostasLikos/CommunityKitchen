using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CompositeFactoryDesign.Concrete
{
    public class Liquid : IConsumable
    {
        private string type;
        public string ConsumableType { get => type; set => type="Liquid"; }
    }
}
