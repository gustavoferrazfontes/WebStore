using Microsoft.AspNet.Identity;

using UserRegistration.Identity.Model;

namespace UserRegistration.Identity.Configuration
{
    public class ApplicationUser : UserManager<IdentityUserApplication>
    {
        public ApplicationUser(IUserStore<IdentityUserApplication> store) : base(store)
        {
            UserValidator = new UserValidator<IdentityUserApplication>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Logica de validação e complexidade de senha
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
        }
    }
}
