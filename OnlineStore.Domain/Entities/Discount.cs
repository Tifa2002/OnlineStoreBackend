namespace OnlineStore.Domain.Entities
{
    public class Discount:BaseEntity
    {
        [MaxLength(30)]
        public string DiscountCode { get; set; } = null!;   //like BlackFirday - Summer Sale etc....
        public DiscountType DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime StartDiscount {  get; set; }
        public DateTime EndDiscount { get; set; }

    }
}
