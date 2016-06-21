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
            throw new NotImplementedException();
        }

        public void Remove(Guid Id)
        {
            throw new NotImplementedException();
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