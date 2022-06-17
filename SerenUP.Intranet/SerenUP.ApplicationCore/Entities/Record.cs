using System.ComponentModel.DataAnnotations;

namespace SerenUP.ApplicationCore.Entities
{
    public class Record : Entity<Guid>
    {
        public string StandardRecord { get; set; }
        public string PlusRecord { get; set; }

    }
}
