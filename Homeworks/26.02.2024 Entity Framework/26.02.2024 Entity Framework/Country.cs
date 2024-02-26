namespace _26._02._2024_Entity_Framework
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public int NumberOfInhabitants { get; set; }
        public double Area { get; set; }
        public virtual PartOfTheWorld PartOfTheWorld { get; set; }
    }
}
