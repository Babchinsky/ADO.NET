namespace Book_Store.Entities
{
    public class BookDiscount
    {
        public int BookId { get; set; }
        public int DiscountId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Discount Discount { get; set; }
    }
}