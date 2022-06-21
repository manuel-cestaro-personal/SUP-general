﻿using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface IProductStatusRepository : IRepository<ProductStatus, Guid>
    {
    }
}
