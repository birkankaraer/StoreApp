using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository // sealed means that this class cannot be inherited
	{
		public ProductRepository(RepositoryContext context) : base(context)
		{

		}

		public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

		public Product? GetOneProduct(int id, bool trackChanges)
		{
			return FindByCondition(p => p.ProductId.Equals(id), trackChanges);
		}

		public void CreateOneProduct(Product product) => Create(product);

		public void DeleteOneProduct(Product product) => Remove(product);

		public void UpdateOneProduct(Product entity) => Update(entity);

		public IQueryable<Product> GetShowaseProducts(bool trackChanges)
		{
			return FindAll(trackChanges).Where(p => p.ShowCase.Equals(true));
		}

		public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
		{
			return _context
				.Products
				.FilteredByCategoryId(p.CategoryId)
				.FilteredBySearchTerm(p.SearchTerm)
				.FilteredByPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice);
		}
	}
}
