
namespace ShirtCatalog.Application.ViewModel
{
    public class VariationViewModel
    {
        public VariationViewModel(int idVariation, int idColor, string colorName, int idFabric, string fabricName, 
            int? idImage, string imagePath)
        {
            IdVariation = idVariation;
            IdColor = idColor;
            ColorName = colorName;
            IdFabric = idFabric;
            FabricName = fabricName;
            IdImage = idImage;
            ImagePath = imagePath;
        }

        public int IdVariation { get; private set; }
        public int IdColor { get; private set; }
        public string ColorName { get; private set; }
        public int IdFabric { get; private set; }
        public string FabricName { get; private set; }
        public int? IdImage { get; private set; }
        public string ImagePath { get; private set; }
    }
}
