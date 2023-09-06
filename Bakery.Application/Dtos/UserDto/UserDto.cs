using Bakery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Dtos.UserDto
{
    public class UserDto
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime SignedInDateTime { get; set; }
        [Required]
        public bool Status { get; set; }
        public ICollection<Order> Orders { get; set; }
        public short Role { get; set; }
    }
}
