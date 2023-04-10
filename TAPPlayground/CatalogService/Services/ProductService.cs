using CatalogService.Models;
using CatalogService.Repositories.Interfaces;
using CatalogService.Services.Interfaces;
namespace CatalogService.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }
    public List<Product> GetAll() => _repo.GetAll();
    public Product GetById(int productId) => _repo.GetById(productId);
    public bool Insert(Product product) => _repo.Insert(product);
    public bool Update(Product product) => _repo.Update(product);
    public bool Delete(int productId) => _repo.Delete(productId);
    public bool HikePrice(double percentage) => _repo.HikePrice(percentage);
}