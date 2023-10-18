using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShirtCatalog.Application.ViewModel
{
    public class ShirtDetailsViewModel
    {
        public ShirtDetailsViewModel(int id, string name, int numberOfColors, int numberOfFabrics, int numberOfImages)
        {
            Id = id;
            Name = name;
            NumberOfColors = numberOfColors;
            NumberOfFabrics = numberOfFabrics;
            NumberOfImages = numberOfImages;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int NumberOfColors { get; private set; }
        public int NumberOfFabrics { get; private set; }
        public int NumberOfImages { get; private set; }
    }
}
