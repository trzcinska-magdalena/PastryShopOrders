using System.ComponentModel.DataAnnotations;

namespace PastryShopOrders.Models.DTOs
{
    public class OrderPOST
    {
        [Required]
        public DateTime AcceptedAt { get; set; }
        [MaxLength(300)]
        public string? Comments { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public IEnumerable<OrderPastryPOST> Pastries { get; set; } = new List<OrderPastryPOST>();
    }
}
