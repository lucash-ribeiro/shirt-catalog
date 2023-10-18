namespace ShirtCatalog.Core.Entities
{
    public class Fabric : BaseEntity
    {
        public Fabric(string name) 
        {
            Name = name;

            Variations = new List<Variation>();
        }

        public string Name { get; private set; }

        public List<Variation> Variations { get; private set; }
    }
}
