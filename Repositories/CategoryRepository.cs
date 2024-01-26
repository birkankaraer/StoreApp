using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
            
        }

		public Category? GetOneCategory(int id, bool trackChanges)
		{
			return FindByCondition(p => p.CategoryId.Equals(id), trackChanges);
		}
	}
}
