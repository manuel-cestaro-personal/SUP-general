using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Entities
{
    public class CartAccessory
    {
        public Guid AccessoryId { get; set; }
        public Guid CartAccessoryId { get; set; }
        public Guid CartId { get; set; }
        public int Quantity { get; set; }

    }
}
