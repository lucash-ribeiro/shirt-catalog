using ShirtCatalog.UI.Models;

namespace ShirtCatalog.UI.Contracts
{
    public interface IShirtService
    {
        Task<List<ShirtViewModel>> GetShirts();
    }
}
