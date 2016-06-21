using ClotheStore.SharedKernel.Events;
using ClotheStore.SharedKernel.Interfaces;
using Register.Core.ApplicationLayer.Commands;
using Register.Core.ApplicationLayer.Interfaces;
using Register.Core.DomainModel.Events;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConferenceSystem.WebApi.Controllers
{
    [RoutePrefix("api/register")]
    public class CategoryManagerController : ApiController
    {
        private readonly ICategoryManager _categoryManager;
        private readonly ICategoryQuery _categoryQuery;
        private readonly INotifiable<DomainNotification> _domainNotification;
        private readonly INotifiable<CategoryRegistered> _categoryRegistered;
        public CategoryManagerController(
            ICategoryManager categoryManager,
            INotifiable<DomainNotification> domainNotification,
            INotifiable<CategoryRegistered> categoryRegistered,
            ICategoryQuery categoryQuery)
        {
            _categoryManager = categoryManager;
            _domainNotification = domainNotification;
            _categoryRegistered = categoryRegistered;
            _categoryQuery = categoryQuery;
        }

        [Route("categories")]
        public Task<IHttpActionResult> PostAsync([FromBody]dynamic body)
        {
            var command = new RegisterCategoryCommand((string)body.title);
            _categoryManager.Register(command);

            if (_domainNotification.HasNotifications())
            {
                _domainNotification.Notify().ToList().ForEach(error => ModelState.AddModelError(error.Key, error.Value));
                return Task.FromResult<IHttpActionResult>(BadRequest(ModelState));
            }
            else if (_categoryRegistered.HasNotifications())
            {
                return Task.FromResult<IHttpActionResult>(Ok(_categoryRegistered.Notify()));
            }
            return Task.FromResult<IHttpActionResult>(Ok(_categoryRegistered.Notify()));


        }

        [Route("categories")]
        public Task<IHttpActionResult> Get()
        {
            var categories = _categoryQuery.GetCategories();
            return Task.FromResult<IHttpActionResult>(Ok(categories));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _domainNotification.Dispose();
            _categoryRegistered.Dispose();
        }
    }


}