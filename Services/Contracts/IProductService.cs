using Entities.DTOs;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
		IEnumerable<Product> GetLastestProducts(int n, bool trackChanges);
		IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
		IEnumerable<Product> GetShowaseProducts(bool trackChanges);
		Product? GetOneProduct(int id, bool trackChanges);
        void CreateProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
		ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
	}
}