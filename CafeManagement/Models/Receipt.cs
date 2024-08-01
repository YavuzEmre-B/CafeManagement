using System;

namespace CafeManagement.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
    }
}
