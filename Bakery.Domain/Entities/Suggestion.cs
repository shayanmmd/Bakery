using Shared.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Domain.Entities
{
    public class Suggestion : IHasGuid
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        [ForeignKey(nameof(Customer))]
        public Guid FkCustomer { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
