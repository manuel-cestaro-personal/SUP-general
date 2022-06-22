﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Entities
{
    internal class CartAccessory : Entity<Guid>
    {
        public Guid AccessoryId { get; set; }
        public Guid CartId { get; set; }
        public int Quantity { get; set; }

    }
}
