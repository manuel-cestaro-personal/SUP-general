using System.ComponentModel.DataAnnotations;

namespace SerenUP.ApplicationCore.Entities
{
    public class Order
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public string OrderAddress { get; set; }
        public DateTime Date { get; set; }
        public int Ordernumber { get; set; }
        public string Status { get; set; }
    }
}
