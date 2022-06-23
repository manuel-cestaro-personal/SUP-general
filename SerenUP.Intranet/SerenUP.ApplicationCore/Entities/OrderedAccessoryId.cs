using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Entities
{
    public class OrderedAccessoryId : Entity<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid AccessoryId { get; set; }

    }
}
