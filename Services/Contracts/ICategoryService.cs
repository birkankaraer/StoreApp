using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
		Category? GetOneCategory(int id, bool trackChanges);
		void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);

    }
}
