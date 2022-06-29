using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Entities
{
    public class CartWatch
    {
        public Guid WatchId { get; set; }
        public Guid CartWatchId { get; set; }
        public Guid CartId { get; set; }

    }
}
