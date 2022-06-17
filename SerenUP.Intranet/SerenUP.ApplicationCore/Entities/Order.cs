using System.ComponentModel.DataAnnotations;

namespace SerenUP.ApplicationCore.Entities
{
    public class Order : Entity<Guid>
    {
        public string OrderAddress { get; set; }
        public DateTime Date { get; set; }
        public int Ordernumber { get; set; }
    }
}
