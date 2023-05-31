namespace PastryShopOrders.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime AcceptedAt { get; set; }
        public DateTime? FulfilledAt { get; set; }
        public string? Comments { get; set; }
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrderPastry> OrderPastries { get; set; } = new List<OrderPastry>();
    }
}
