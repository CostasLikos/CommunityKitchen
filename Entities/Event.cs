using Entities.IdentityModel;
using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Event :IAttributes,ISubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        //IAttributes Implementation

        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }

        public string ModeratorId { get; set; }
        public ApplicationUser Moderator { get; set; }

        private DateTime date;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventDate 
        {
            get { return date; }
            set 
            { 
                date = value;
                NotifyRegistredUsers(value);
            }
        }

        //Observers
        List<IWatcher> observerList = new List<IWatcher>();
        public void Register(IWatcher watcher)=>observerList.Add(watcher);
        public void Unregister(IWatcher watcher)=>observerList.Remove(watcher);
        public void NotifyRegistredUsers(DateTime date)
        {
            foreach (IWatcher watcher in observerList)
            {
                watcher.Update(date);
            }
        }
    }
}
