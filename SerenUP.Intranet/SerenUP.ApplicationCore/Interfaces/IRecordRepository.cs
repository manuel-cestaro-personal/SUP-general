using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface IRecordRepository
    {
        Task<IEnumerable<Record>> GetAll();
        Task<Record> GetById(Guid id);
        Task Insert(Record model);
        Task Update(Record model);
        Task Delete(Guid id);
    }
}
