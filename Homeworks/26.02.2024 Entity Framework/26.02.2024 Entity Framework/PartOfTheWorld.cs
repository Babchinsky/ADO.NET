namespace _26._02._2024_Entity_Framework
{
    public class PartOfTheWorld
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Country>? Countries { get; set; }
    }
}
