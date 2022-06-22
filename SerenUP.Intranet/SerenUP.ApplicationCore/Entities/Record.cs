using System.ComponentModel.DataAnnotations;

namespace SerenUP.ApplicationCore.Entities
{
    public class Record : Entity<Guid>
    {
        public Guid WatchId { get; set; }
        public string StandardRecord { get; set; }
        public string PlusRecord { get; set; }

    }
}
