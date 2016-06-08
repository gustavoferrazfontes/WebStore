using UserRegistration.Core.Domain.Model.Model.UserAggregate;

namespace UserRegistration.Core.Domain.Model.UserAggregate.Interfaces
{
    public interface IUserRepository
    {
        User FindUser(string id);
    }
}
