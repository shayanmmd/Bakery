using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Dtos.BakeryDto
{
    public class BakeryDto
    {
        public Guid Guid { get; set; }
        public string BakeryName { get; set; }
        public string OwnerName { get; set; }
        public DateTime CreationDateTime { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public string PhoneNumber { get; set; }
    }
}
