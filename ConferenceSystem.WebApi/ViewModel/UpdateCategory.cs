using System.ComponentModel.DataAnnotations;

namespace ConferenceSystem.WebApi.ViewModel
{
    public sealed class UpdateCategory
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Id { get; set; }
    }
}