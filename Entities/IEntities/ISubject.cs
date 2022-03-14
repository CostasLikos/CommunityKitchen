using Entities.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IEntities
{
    internal interface ISubject
    {
        void Register(IWatcher watcher);
        void Unregister(IWatcher watcher);
        void NotifyRegistredUsers(DateTime date);

    }
}
