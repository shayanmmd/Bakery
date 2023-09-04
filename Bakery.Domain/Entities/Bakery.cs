using Shared.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Domain.Entities
{
    public class Bakery : IHasGuid, IHasStatus
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public string BakeryName { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public byte[] Image { get; set; }
        public string PhoneNumber { get; set; }

    }
}
