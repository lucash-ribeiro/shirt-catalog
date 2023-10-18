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
    public class ShirtService : IShirtService
    {
        private readonly ShirtCatalogDbContext _dbContext;
        private readonly IMapper _mapper;

        public ShirtService(IMapper mapper, ShirtCatalogDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ShirtDetailsViewModel GetById(int id)
        {
            var shirt = _dbContext.Shirts
                .Where(s => s.Id == id)
                .SingleOrDefault();

            if (shirt == null) return null;

            var shirtDetailsViewModel = new ShirtDetailsViewModel(shirt.Id, shirt.Name,
                _dbContext.Variations
                    .Where(v => v.Shirt.Id == shirt.Id)
                    .Select(v => v.Color.Id)
                    .Distinct()
                    .Count(),
                _dbContext.Variations
                    .Where(v => v.Shirt.Id == shirt.Id)
                    .Select(v => v.Fabric.Id)
                    .Distinct()
                    .Count(),
                _dbContext.Images
                    .Where(i => _dbContext.Variations
                        .Where(v => v.IdShirt == shirt.Id)
                        .Select(v => v.Id)
                        .ToList().Contains(i.IdVariation))
                    .Select(v => v.Id)
                    .Count());

            return shirtDetailsViewModel;
        }

        public async Task<List<ShirtDetailsViewModel>> GetAll()
        {
            var shirts = await _dbContext.Shirts
                .Select(s => new ShirtDetailsViewModel(s.Id, s.Name,
                    _dbContext.Variations
                        .Where(v => v.Shirt.Id == s.Id)
                        .Select(v => v.Color.Id)
                        .Distinct()
                        .Count(),
                    _dbContext.Variations
                        .Where(v => v.Shirt.Id == s.Id)
                        .Select(v => v.Fabric.Id)
                        .Distinct()
                        .Count(),
                    _dbContext.Images
                        .Where(i => _dbContext.Variations
                            .Where(v => v.IdShirt == s.Id)
                            .Select(v => v.Id)
                            .ToList().Contains(i.IdVariation))
                        .Select(v => v.Id)
                        .Count()))
                .ToListAsync();

            if (shirts == null) return null;

            var shirtDetailsViewModel = _mapper.Map<List<ShirtDetailsViewModel>>(shirts);

            return shirtDetailsViewModel;
        }

        public async Task<int> GetDistinctShirtColorCountAsync(int idShirt)
        {
            int distinctCount = await _dbContext.Variations
                .Where(v => v.IdShirt == idShirt)
                .Select(v => v.IdShirt)
                .Distinct()
                .CountAsync();

            return distinctCount;
        }

        public int Create(NewShirtInputModel inputModel)
        {
            var shirt = new Shirt(inputModel.Name);

            _dbContext.Shirts.Add(shirt);
            _dbContext.SaveChanges();

            return shirt.Id;
        }

        public void Update(UpdateShirtInputModel inputModel)
        {
            var shirt = _dbContext.Shirts.SingleOrDefault(s => s.Id == inputModel.Id);

            shirt.Update(inputModel.Name);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var shirt = _dbContext.Shirts.SingleOrDefault(s => s.Id == id);

            _dbContext.Shirts.Remove(shirt);
            _dbContext.SaveChanges();
        }
    }
}
