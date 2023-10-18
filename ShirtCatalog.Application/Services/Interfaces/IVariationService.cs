using ShirtCatalog.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShirtCatalog.Application.Services.Interfaces
{
    public interface IVariationService
    {
        Task<List<VariationViewModel>> GetAllByShirtAsync(int idShirt);
        void DeleteImage(int id);
        int InsertImage(int idVariation, string imageName);
    }
}
