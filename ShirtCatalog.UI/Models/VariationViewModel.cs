using System.ComponentModel;

namespace ShirtCatalog.UI.Models
{
    public class VariationViewModel
    {
        public int IdVariation { get;  set; }
        public int IdColor { get;  set; }
        public string ColorName { get;  set; }
        public int IdFabric { get;  set; }
        public string FabricName { get;  set; }
        public int? IdImage { get;  set; }
        public string ImagePath { get;  set; }
    }
}
