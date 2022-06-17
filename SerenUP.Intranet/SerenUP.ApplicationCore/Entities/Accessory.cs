using System.ComponentModel.DataAnnotations;

namespace SerenUP.ApplicationCore.Entities
{
    public class Accessory : Entity<Guid>
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
    }
}
