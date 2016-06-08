using System.Linq;
using UserRegistration.Core.Domain.Model.Model.UserAggregate;
using UserRegistration.Core.Domain.Model.UserAggregate.Interfaces;
using UserRegistration.Data.Context;

namespace UserRegistration.Data.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly UserRegistrationContext _context;

        public UserRepository(UserRegistrationContext context)
        {
            _context = context;
        }

        public User FindUser(string id)
        {
            return _context.User.FirstOrDefault(_ => _.Id == id);
        }
    }
}
