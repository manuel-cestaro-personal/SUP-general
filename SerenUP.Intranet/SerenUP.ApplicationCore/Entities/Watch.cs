using SerenUP.ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace SerenUP.ApplicationCore.Entitiess
{
    public class Watch : Entity<Guid>
    {
        public decimal Price { get; set; }
        public string MacAddress { get; set; }
        public string SerialNumber { get; set; }
        public string ActivationKey { get; set; }
        public string Color { get; set; }

    }
}
