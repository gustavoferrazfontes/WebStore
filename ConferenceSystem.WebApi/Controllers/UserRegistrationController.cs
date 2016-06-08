using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UserRegistration.Identity.Configuration;
using UserRegistration.Identity.Model;

namespace ConferenceSystem.WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class UserRegistrationController : ApiController
    {

        private readonly ApplicationUser _applicationUser;
        public UserRegistrationController(ApplicationUser applicationUser)
        {
            _applicationUser = applicationUser;
        }
        [HttpPost]
        [Route("users")]
        public async Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new IdentityUserApplication((string)body.email, (string)body.email);

            var created = await _applicationUser.CreateAsync(command, (string)body.password);

            if (created.Succeeded)
                return Request.CreateResponse(HttpStatusCode.Created, command);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, created.Errors);

        }
    }
}
