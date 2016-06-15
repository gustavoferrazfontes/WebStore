using System;

namespace Register.Core.DomainModel.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        void SaveNewCategory(Category category);
        void Remove(Guid Id);
        void Remove(object id);
        Category GetCategory(Guid guid);
    }
}
