using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        private readonly IProductRepository _productrepository;

        private readonly ICategoryRepository _categoryrepository;

        private readonly IOrderRepository _orderrepository;

		public RepositoryManager(IProductRepository productrepository, RepositoryContext context, ICategoryRepository categoryrepository, IOrderRepository orderrepository)
		{
			_context = context;
			_productrepository = productrepository;
			_categoryrepository = categoryrepository;
			_orderrepository = orderrepository;
		}

		public IProductRepository Product => _productrepository;

        public ICategoryRepository Category => _categoryrepository;

        public IOrderRepository Order => _orderrepository;

		public void Save()
        {
            _context.SaveChanges();
        }
    }
}
