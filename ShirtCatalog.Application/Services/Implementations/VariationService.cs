using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShirtCatalog.Application.InputModels;
using ShirtCatalog.Application.Services.Interfaces;
using ShirtCatalog.Application.ViewModel;
using ShirtCatalog.Core.Entities;
using ShirtCatalog.Infrastructure.Persistence;

namespace ShirtCatalog.Application.Services.Implementations
{
    public class VariationService
        : IVariationService
    {
        private readonly ShirtCatalogDbContext _dbContext;
        private readonly IMapper _mapper;

        public VariationService(IMapper mapper, ShirtCatalogDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<List<VariationViewModel>> GetAllByShirtAsync(int idShirt)
        {
            var data = await (from v in _dbContext.Variations
                              join f in _dbContext.Fabrics on v.IdFabric equals f.Id
                              join c in _dbContext.Colors on v.IdColor equals c.Id
                              join i in _dbContext.Images on v.Id equals i.IdVariation into imgGroup
                              from i in imgGroup.DefaultIfEmpty()
                              where v.IdShirt == idShirt
                              select new VariationViewModel(v.Id, c.Id, c.Name, f.Id, f.Name, i.Id, i.ImagePath)).ToListAsync();
            
            return data;
        }

        public void DeleteImage(int id)
        {
            var image = _dbContext.Images.SingleOrDefault(i => i.Id == id);

            if (image == null)
            {
                return;
            }

            string apiBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(apiBaseDirectory).Parent.Parent.Parent.Parent.FullName; // Move up to the "ProductCatalog" folder

            string imageDirectory = Path.Combine(projectRoot, "ShirtCatalog.UI", "wwwroot", "upload", "images");
            string fullPath = Path.Combine(imageDirectory, image.ImagePath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            _dbContext.Images.Remove(image);
            _dbContext.SaveChanges();
        }

        public int InsertImage(int idVariation, string imageName)
        {
            var image = new Image(idVariation, imageName);

            _dbContext.Images.Add(image);
            _dbContext.SaveChanges();

            return image.Id;
        }

    }
}
