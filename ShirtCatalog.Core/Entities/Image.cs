
namespace ShirtCatalog.Core.Entities
{
    public class Image : BaseEntity
    {
        public Image(int idVariation, string imagePath) 
        {
            IdVariation = idVariation;
            ImagePath = imagePath;
        }

        public int IdVariation { get; private set; }
        public Variation Variation { get; private set; }
        public string ImagePath { get; private set; }
    }
}
