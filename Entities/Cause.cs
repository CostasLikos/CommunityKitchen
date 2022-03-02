using Entities.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cause : IAttributes
    {
        public Guid Id { get; set; }
        //IAttribute Implementation
        public string Title { get; set ; }
        public string Description { get ; set ; }
        public string Photo { get; set; }
        //Additional Properties
        public double TargetGoal { get; set; }
        public double CurrentAmmount { get; set; }
        //Navigation Properties---Creator Link
        public Guid ModeratorId { get; set; }
        public Moderator Moderator { get; set; }
    }
}
