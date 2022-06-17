using System.ComponentModel.DataAnnotations;

namespace SerenUP.ApplicationCore.Entities
{
    public class OrderStatus : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
