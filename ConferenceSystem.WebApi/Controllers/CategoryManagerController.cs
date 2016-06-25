using ClotheStore.SharedKernel.Events;
using ClotheStore.SharedKernel.Interfaces;
using ConferenceSystem.WebApi.ViewModel;
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
        private readonly INotifiable<CategoryUpdated> _categoryUpdated;
        private readonly INotifiable<CategoryRemoved> _categoryRemoved;
        public CategoryManagerController(
            ICategoryManager categoryManager,
            INotifiable<DomainNotification> domainNotification,
            INotifiable<CategoryRegistered> categoryRegistered,
            INotifiable<CategoryUpdated> categoryUpdated,
            INotifiable<CategoryRemoved> categoryRemoved,
            ICategoryQuery categoryQuery)
        {
            _categoryManager = categoryManager;
            _domainNotification = domainNotification;
            _categoryRegistered = categoryRegistered;
            _categoryUpdated = categoryUpdated;
            _categoryRemoved = categoryRemoved;
            _categoryQuery = categoryQuery;
        }


        [Route("categories")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            var categories = await Task.FromResult(_categoryQuery.GetCategories());
            return Ok(categories);
        }

        [Route("categories")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody] NewCategory body)
        {
            var command = new RegisterCategoryCommand(body.Title);
            _categoryManager.Register(command);

            if (_domainNotification.HasNotifications())
            {
                _domainNotification.Notify().ToList().ForEach(error => ModelState.AddModelError(error.Key, error.Value));
                return await Task.FromResult(BadRequest(ModelState));
            }

            return await Task.FromResult(Ok(_categoryRegistered.Notify()));


        }

        [Route("categories")]
        [HttpPut]
        public async Task<IHttpActionResult> PutAsync([FromBody] UpdateCategory updateCategory)
        {
            var command = new UpdateCategoryCommand(updateCategory.Title, updateCategory.Id);
            _categoryManager.Update(command);
            if (_domainNotification.HasNotifications())
            {
                _domainNotification.Notify().ToList().ForEach(error => ModelState.AddModelError(error.Key, error.Value));
                return await Task.FromResult(BadRequest(ModelState));
            }

            return await Task.FromResult(Ok(_categoryUpdated.Notify()));
        }

        [Route("categories/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAsync(string id)
        {
            var command = new RemoveCategoryCommand(id);
            _categoryManager.Remove(command);
            if (_domainNotification.HasNotifications())
            {
                _domainNotification.Notify().ToList().ForEach(error => ModelState.AddModelError(error.Key, error.Value));
                return await Task.FromResult(BadRequest(ModelState));
            }

            return await Task.FromResult(Ok(_categoryRemoved.Notify()));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _domainNotification.Dispose();
            _categoryRegistered.Dispose();
            _categoryUpdated.Dispose();
            _categoryRemoved.Dispose();
        }


    }


}