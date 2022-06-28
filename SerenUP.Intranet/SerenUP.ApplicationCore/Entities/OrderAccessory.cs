using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Entities
{
    public class OrderAccessory
    {
        public Guid OrderId { get; set; }
        public Guid OrderAccessoryId { get; set; }
        public Guid AccessoryId { get; set; }

    }
}
