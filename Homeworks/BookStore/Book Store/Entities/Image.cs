namespace Book_Store.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        public virtual Book Book { get; set; }
    }
}