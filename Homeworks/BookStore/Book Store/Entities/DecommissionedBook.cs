namespace Book_Store.Entities
{
    public class DecommissionedBook
    {
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}