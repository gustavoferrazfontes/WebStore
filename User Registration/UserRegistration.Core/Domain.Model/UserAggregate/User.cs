using System;

namespace UserRegistration.Core.Domain.Model.Model.UserAggregate
{
    public sealed class User
    {
        public string Id { get; private set; }
        public string Email { get; private set; }
        public string EmailConfirmed { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
