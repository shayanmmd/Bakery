using Bakery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Dtos.OrderDto
{
    public class OrderDto
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }
        [Required]
        [ForeignKey(nameof(Customer))]
        public Guid FkCustomer { get; set; }
        public virtual User Customer { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        public string TrackingCode { get; set; }
        [Required]
        public long TotalPrice { get; set; }
    }
}
