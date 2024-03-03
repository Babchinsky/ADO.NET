namespace CountryLibrary
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }
        public virtual PartOfTheWorld PartOfTheWorld { get; set; }
    }
}
