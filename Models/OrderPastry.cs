namespace PastryShopOrders.Models
{
    public class OrderPastry
    {
        public int OrderID { get; set; }
        public int PastryID { get; set; }
        public int Amount { get; set; }
        public string? Comme { get; set; }
    }
}
