using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IEntities
{
    public interface IAttributes
    {
        string Title { get; set; }
        string Description { get; set; }
        string Photo { get; set; }
    }
}
