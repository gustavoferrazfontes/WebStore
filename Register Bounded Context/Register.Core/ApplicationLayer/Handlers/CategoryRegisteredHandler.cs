using System.Collections.Generic;
using ClotheStore.SharedKernel.Interfaces;
using Register.Core.DomainModel.Events;

namespace Register.Core.ApplicationLayer.Handlers
{
    public sealed class CategoryRegisteredHandler : INotifiable<CategoryRegistered>, IHandler<CategoryRegistered>
    {
        private List<CategoryRegistered> lstCategoryRegistered;

        public CategoryRegisteredHandler()
        {
            lstCategoryRegistered = new List<CategoryRegistered>();
        }
        public void Dispose()
        {
            lstCategoryRegistered = new List<CategoryRegistered>();
        }

        public void Handle(CategoryRegistered args)
        {
            lstCategoryRegistered.Add(args);
        }

        public bool HasNotifications()
        {
            return lstCategoryRegistered.Count > 0;
        }

        public IEnumerable<CategoryRegistered> Notify()
        {
            return lstCategoryRegistered;
        }
    }
}
