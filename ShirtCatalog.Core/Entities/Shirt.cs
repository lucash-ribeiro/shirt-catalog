using ShirtCatalog.Core.Enums;

namespace ShirtCatalog.Core.Entities
{
    public class Shirt : BaseEntity
    {
        public Shirt(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public List<Variation> Variations { get; private set; }

        public void Update(string name)
        {
            Name = name;
        }
    }
}