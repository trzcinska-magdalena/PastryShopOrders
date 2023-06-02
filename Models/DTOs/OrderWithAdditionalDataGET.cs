namespace PastryShopOrders.Models.DTOs
{
    public class OrderWithAdditionalDataGET
    {
        public int ID { get; set; }
        public DateTime AcceptedAt { get; set; }
        public DateTime? FulfilledAt { get; set; }
        public string? Comments { get; set; }
        public IEnumerable<Pastry> Pastries { get; set; } = new List<Pastry>();
    }
}
