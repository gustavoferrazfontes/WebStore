using System;
using System.Collections.Generic;
using ClotheStore.SharedKernel.Interfaces;
using Register.Core.DomainModel.Events;

namespace Register.Core.ApplicationLayer.Handlers
{
    public sealed class CategoryUpdatedHandler : INotifiable<CategoryUpdated>, IHandler<CategoryUpdated>
    {
        private List<CategoryUpdated> lstCategoriesUpdated;
        public CategoryUpdatedHandler()
        {
            lstCategoriesUpdated = new List<CategoryUpdated>();
        }
        public void Dispose()
        {
            lstCategoriesUpdated = new List<CategoryUpdated>();
        }

        public void Handle(CategoryUpdated args)
        {
            lstCategoriesUpdated.Add(args);
        }

        public bool HasNotifications()
        {
            return lstCategoriesUpdated.Count > 0;
        }

        public IEnumerable<CategoryUpdated> Notify()
        {
            return lstCategoriesUpdated;
        }
    }
}
