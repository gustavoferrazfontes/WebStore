using System.Collections.Generic;
using Register.Core.ApplicationLayer.Interfaces;
using Register.Core.DomainModel.Interfaces.Repository;
using System.Linq;
using Register.Core.DomainModel;

namespace Register.Core.ApplicationLayer.Queries
{
    public sealed class CategoryQuery : ICategoryQuery
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryQuery(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<ListOfCategory> GetCategories()
        {
            var categories = _categoryRepository.GetAll();
            return Convert(categories);

        }

        private static IEnumerable<ListOfCategory> Convert(IEnumerable<Category> categories)
        {
            var lstCategories = new List<ListOfCategory>();
            categories.ToList().ForEach(category => lstCategories.Add(new ListOfCategory { Id = category.Id.ToString(), Name = category.Title }));
            return lstCategories;
        }
    }
}
