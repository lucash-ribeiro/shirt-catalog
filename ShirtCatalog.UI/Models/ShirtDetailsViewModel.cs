using System.ComponentModel;

namespace ShirtCatalog.UI.Models
{
    public class ShirtDetailsViewModel
    {
        [DisplayName("Item")]
        public int Id { get; set; }

        [DisplayName("Shirt")]
        public string Name { get; set; }

        public List<VariationViewModel> Variations { get; set; } = new List<VariationViewModel>();

    }
}
