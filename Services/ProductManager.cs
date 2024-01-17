using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class ProductManager : IProductService
	{
		private readonly IRepositoryManager _manager;
		private readonly IMapper _mapper;

		public ProductManager(IRepositoryManager manager, IMapper mapper)
		{
			_manager = manager;
			_mapper = mapper;
		}

		public void CreateProduct(ProductDtoForInsertion productDto)
		{
			Product product = _mapper.Map<Product>(productDto);
			_manager.Product.Create(product);
			_manager.Save();
		}
		public IEnumerable<Product> GetAllProducts(bool trackChanges)
		{
			return _manager.Product.GetAllProducts(trackChanges);
		}

		public Product? GetOneProduct(int id, bool trackChanges)
		{
			var product = _manager.Product.GetOneProduct(id, trackChanges);
			if (product == null)
			{
				throw new Exception("Product not found!");
			}
			return product;
		}

		public void UpdateOneProduct(ProductDtoForUpdate productDto)
		{
			//var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
			//entity.ProductName = productDto.ProductName;
			//entity.Price = productDto.Price;
			//entity.CategoryId = productDto.CategoryId;
			var entity = _mapper.Map<Product>(productDto);
			_manager.Product.UpdateOneProduct(entity);
			_manager.Save();
		}

		public void DeleteOneProduct(int id)
		{
			Product product = GetOneProduct(id, false);
			if (product is not null)
			{
				_manager.Product.DeleteOneProduct(product);
				_manager.Save();
			}
		}

		public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
		{
			var product = GetOneProduct(id, trackChanges);
			var productDto = _mapper.Map<ProductDtoForUpdate>(product);
			return productDto;
		}

		public IEnumerable<Product> GetShowaseProducts(bool trackChanges)
		{
			var products = _manager.Product.GetShowaseProducts(trackChanges);
			return products;
		}

		public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
		{
			return _manager.Product.GetAllProductsWithDetails(p);
		}

		public IEnumerable<Product> GetLastestProducts(int n, bool trackChanges)
		{
			return _manager.Product.FindAll(trackChanges)
				.OrderByDescending(p => p.ProductId)
				.Take(n);
		}
	}
}
