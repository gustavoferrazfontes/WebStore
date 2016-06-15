using System;
using ClotheStore.SharedKernel.Events;
using ClotheStore.SharedKernel.Interfaces;
using Register.Core.ApplicationLayer.Commands;
using Register.Core.ApplicationLayer.Interfaces;
using Register.Core.DomainModel;
using Register.Core.DomainModel.Events;
using Register.Core.DomainModel.Interfaces.Repository;

namespace Register.Core.ApplicationLayer.UseCases
{
    public class CategoryManager : UseCaseBase, ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository, INotifiable<DomainNotification> domainNotification, IUnitOfWork uow) : base(domainNotification, uow)
        {
            _categoryRepository = categoryRepository;
        }

        public void Register(RegisterCategoryCommand command)
        {
            var newCategory = new Category(command.Title);
            newCategory.CreationIsValid();
            _categoryRepository.SaveNewCategory(newCategory);
            if (Commit())
            {
                DomainEvent.Raise(new CategoryRegistered(newCategory));
            }

        }

        public void Remove(RemoveCategoryCommand command)
        {
            _categoryRepository.Remove(command.Id);
            if (Commit())
            {
                DomainEvent.Raise(new CategoryRemoved(command.Id));
            }
        }

        public void Update(UpdateCategoryCommand command)
        {
            var category = _categoryRepository.GetCategory(command.Id);
            category.ChangeData(command.Title);
            category.ChangeIsValid();
            if (Commit())
            {
                DomainEvent.Raise(new CategoryUpdated(category));
            }
        }
    }
}
