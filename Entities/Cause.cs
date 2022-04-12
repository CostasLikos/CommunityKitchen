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
    public class Cause : IAttributes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        //IAttribute Implementation
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(30)]
        public string Title { get; set ; }
        public string Description { get ; set ; }
        public string Photo { get; set; }
        //Additional Properties
        [Range(1, 1000000), DataType(DataType.Currency)]
        public double TargetGoal { get; set; }
        [Range(0, 1000000), DataType(DataType.Currency)]
        public double CurrentAmmount { get; set; }
        //Navigation Properties---Creator Link
        public Guid ModeratorId { get; set; }
        public ApplicationUser Moderator { get; set; }
    }
}
