using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Infrastructure.Data
{
    public class RecordRepository : IRecordRepository
    { 
        public Task<IEnumerable<Record>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Record> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Record model)
        {
            throw new NotImplementedException();
        }

        public Task Update(Record model)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
