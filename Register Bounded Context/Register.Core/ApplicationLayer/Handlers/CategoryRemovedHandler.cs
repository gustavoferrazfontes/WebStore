using System.Collections.Generic;
using ClotheStore.SharedKernel.Interfaces;
using Register.Core.DomainModel.Events;

namespace Register.Core.ApplicationLayer.Handlers
{
    public sealed class CategoryRemovedHandler : INotifiable<CategoryRemoved>, IHandler<CategoryRemoved>
    {
        private List<CategoryRemoved> lstCategoriesRemoved;

        public CategoryRemovedHandler()
        {
            lstCategoriesRemoved = new List<CategoryRemoved>();
        }

        public void Dispose()
        {
            lstCategoriesRemoved = new List<CategoryRemoved>();
        }

        public void Handle(CategoryRemoved args)
        {
            lstCategoriesRemoved.Add(args);
        }

        public bool HasNotifications()
        {
            return lstCategoriesRemoved.Count > 0;
        }

        public IEnumerable<CategoryRemoved> Notify()
        {
            return lstCategoriesRemoved;
        }
    }
}
