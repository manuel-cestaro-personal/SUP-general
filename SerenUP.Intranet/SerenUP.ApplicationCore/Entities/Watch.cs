using SerenUP.ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace SerenUP.ApplicationCore.Entities
{
    public class Watch : Entity<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductStatusId { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string MacAddress { get; set; }
        public Guid ActivationKey { get; set; }
        public string Color { get; set; }

    }
}
