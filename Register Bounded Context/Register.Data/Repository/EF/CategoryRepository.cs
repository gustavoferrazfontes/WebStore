using Register.Core.DomainModel.Interfaces.Repository;
using System;
using Register.Core.DomainModel;
using Register.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Register.Data.Repository.EF
{
    public sealed class CategoryRepository : ICategoryRepository
    {
        private readonly RegisterContext _context;

        public CategoryRepository(RegisterContext context)
        {
            _context = context;
        }

        public Category GetCategory(Guid guid)
        {
            return _context.Categories.Find(guid);
        }

        public void Remove(Guid Id)
        {
            var category = _context.Categories.Find(Id);
            _context.Categories.Remove(category);
        }

        public void SaveNewCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
;