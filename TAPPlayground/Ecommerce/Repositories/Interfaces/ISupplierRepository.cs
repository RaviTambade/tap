using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface ISupplierRepository{
    List<Supplier> GetAll();

    Supplier GetById(int id);

    List<Supplier> GetSuppliers(int productId);

    bool Insert(Supplier supplier);
    bool Update(Supplier supplier);

    bool Delete(int supplierId);
    
    
}