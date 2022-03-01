using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IEntities
{
    public interface IEventCauseLists
    {
        List<Event> Events { get; set; }
        List<Cause> Causes { get; set; }
    }
}
