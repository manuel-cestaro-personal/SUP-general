using System.ComponentModel.DataAnnotations;

namespace SerenUP.ApplicationCore.Entities
{
    public class Record
    {
        public Guid WatchId { get; set; }
        public Guid RecordId { get; set; }
        public string StandardRecord { get; set; }
        public string PlusRecord { get; set; }

    }
}
