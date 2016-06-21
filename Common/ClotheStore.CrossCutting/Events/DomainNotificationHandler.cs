using ClotheStore.SharedKernel.Events;
using ClotheStore.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace ClotheStore.CrossCutting.Events
{
    public class DomainNotificationHandler : IHandler<DomainNotification>, INotifiable<DomainNotification>
    {
        private List<DomainNotification> lstDomainNotifications;
        public void Dispose()
        {
            lstDomainNotifications = new List<DomainNotification>();
        }

        public DomainNotificationHandler()
        {
            lstDomainNotifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification args)
        {
            lstDomainNotifications.Add(args);
        }

        public bool HasNotifications()
        {
            return lstDomainNotifications.Count > 0;
        }

        public IEnumerable<DomainNotification> Notify()
        {
            return lstDomainNotifications;
        }
    }
}
