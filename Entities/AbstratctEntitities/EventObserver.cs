using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AbstratctEntitities
{
    public abstract class EventObserver
    {
        private DateTime date;
        private List<IWatcher<Event>> volunteers = new List<IWatcher<Event>>();
        
        //CTOR
        public EventObserver(DateTime date)
        {
            this.date = date;
        }

        //Observer Methods
        public void Attach(IWatcher<Event> volunteer)
        {
            volunteers.Add(volunteer);
        }
        public void Detach(IWatcher<Event> volunteer)
        {
            volunteers.Remove(volunteer);
        }
        public void Notify()
        {
            //foreach (IWatcher<Event> volunteer in volunteers)
            //{
            //    volunteer.Update((Event)this);
            //}
        }

        //backfield to Property get-set
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    Notify();
                }
            }
        }

    }
}
