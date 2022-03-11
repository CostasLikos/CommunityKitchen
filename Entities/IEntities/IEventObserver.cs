using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IEntities
{
    internal interface ISubject<T> where T : class
    {
        void Register();
        void Unregister();
        void NotifyRegistredUsers();

    }
}
