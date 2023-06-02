using System.ComponentModel.DataAnnotations;

namespace PastryShopOrders.Models.DTOs
{
    public class OrderPastryPOST
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
        [MaxLength(300)]
        public string? Comments { get; set; }
    }
}
