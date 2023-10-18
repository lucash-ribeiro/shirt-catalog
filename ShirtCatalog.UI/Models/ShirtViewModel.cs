using System.ComponentModel;

namespace ShirtCatalog.UI.Models
{
    public class ShirtViewModel
    {
        [DisplayName("Item")]
        public int Id { get; set; }

        [DisplayName("Shirt")]
        public string Name { get; set; }

        [DisplayName("Number Of Colors")]
        public int NumberOfColors { get; set; }

        [DisplayName("Number Of Fabrics")]
        public int NumberOfFabrics { get; set; }

        [DisplayName("Number Of Images")]
        public int NumberOfImages { get; set; }
    }
}
