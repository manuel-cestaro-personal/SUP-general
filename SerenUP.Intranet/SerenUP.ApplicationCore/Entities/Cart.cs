using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Entities
{
    internal class Cart : Entity<Guid>
    {
        public Guid UserId { get; set; }
    }
}
