using Register.Core.ApplicationLayer.Queries;
using System;
using System.Collections.Generic;

namespace Register.Core.DomainModel.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        void SaveNewCategory(Category category);
        void Remove(Guid Id);
        Category GetCategory(Guid guid);
        IEnumerable<Category> GetAll();
    }
}
