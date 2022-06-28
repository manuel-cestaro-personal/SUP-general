namespace SerenUP.WebApp.Models
{
    public class AccessoryDetail
    {
        public Guid AccessoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public string? Link { get; set; }
    }
}
