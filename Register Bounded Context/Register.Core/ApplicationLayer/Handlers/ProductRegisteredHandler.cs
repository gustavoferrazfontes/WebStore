using ClotheStore.SharedKernel.Interfaces;
using Register.Core.DomainModel.Events;
using System.Collections.Generic;

namespace Register.Core.ApplicationLayer.Handlers
{
    public class ProductRegisteredHandler : INotifiable<ProductRegistered>, IHandler<ProductRegistered>
    {
        public List<ProductRegistered> lstProductsRegistered;

        public ProductRegisteredHandler()
        {
            lstProductsRegistered = new List<ProductRegistered>();
        }
        public void Dispose()
        {
            lstProductsRegistered = new List<ProductRegistered>();
        }

        public void Handle(ProductRegistered args)
        {
            lstProductsRegistered.Add(args);
        }

        public bool HasNotifications()
        {
            return lstProductsRegistered.Count > 0;
        }

        public IEnumerable<ProductRegistered> Notify()
        {
            return lstProductsRegistered;
        }
    }
}
