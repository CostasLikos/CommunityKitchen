using Entities.AbstratctEntitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IEntities
{
    public interface IWatcher<T>where T:class
    {
        void Update(T observer);
    }
}
