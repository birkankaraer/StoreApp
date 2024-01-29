using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
		public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
        }

        public void CreateCategory(Category category)
        {
            _manager.Category.Create(category);
            _manager.Save();
        }

		
		public Category? GetOneCategory(int id, bool trackChanges)
		{
            var category = _manager.Category.GetOneCategory(id, trackChanges);
            if (category == null)
            {
				throw new Exception("Category not found!");
			}
            return category;
		}

		public void UpdateCategory(Category category)
		{
			
				_manager.Category.Update(category);
				_manager.Save();
			
		}

		public void DeleteCategory(int id)
		{
			Category category = GetOneCategory(id, false);
			if (category is not null)
			{
				_manager.Category.Remove(category);
				_manager.Save();
			}

		}
	}
}
