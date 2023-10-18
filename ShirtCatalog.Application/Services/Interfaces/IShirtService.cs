using ShirtCatalog.Application.InputModels;
using ShirtCatalog.Application.ViewModel;

namespace ShirtCatalog.Application.Services.Interfaces
{
    public interface IShirtService
    {
        int Create(NewShirtInputModel inputModel);
        void Update(UpdateShirtInputModel inputModel);
        void Delete(int id);
        ShirtDetailsViewModel GetById(int id);
        Task<List<ShirtDetailsViewModel>> GetAll();
    }
}
