using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IEntities
{
    public interface IWatcher
    {
        void Update(DateTime date,string eventName);
    }
}
