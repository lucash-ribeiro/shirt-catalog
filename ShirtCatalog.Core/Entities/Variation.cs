
namespace ShirtCatalog.Core.Entities
{
    public class Variation : BaseEntity
    {
        public Variation(int idShirt, int idColor, int idFabric) 
        {
            IdShirt = idShirt;
            IdColor = idColor;
            IdFabric = idFabric;
        }

        public int IdShirt{ get; private set; }
        public Shirt Shirt { get; private set; }
        public int IdColor { get; private set; }
        public Color Color { get; private set; }
        public int IdFabric { get; private set; }
        public Fabric Fabric { get; private set; }
        public List<Image> Images { get; private set; }
    }
}
