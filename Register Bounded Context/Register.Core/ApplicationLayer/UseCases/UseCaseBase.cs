using ClotheStore.SharedKernel.Events;
using ClotheStore.SharedKernel.Interfaces;

namespace Register.Core.ApplicationLayer.UseCases
{
    public class UseCaseBase
    {
        private readonly INotifiable<DomainNotification> _domainNotification;
        private readonly IUnitOfWork _uow;
        public UseCaseBase(INotifiable<DomainNotification> domainNotification, IUnitOfWork uow)
        {
            _domainNotification = domainNotification;
            _uow = uow;
        }

        public bool Commit()
        {
            if (!_domainNotification.HasNotifications())
            {
                _uow.Commit();
                return true;
            }
            else
            {
                _uow.Rollback();
                return false;
            }
        }

    }
}
