using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IEntities
{
    public interface IItem
    {
        Guid Id { get; set; }
        string ItemName { get; set; }
        int Quantity { get; set; }
    }
}
