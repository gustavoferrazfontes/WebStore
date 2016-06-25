using System.ComponentModel.DataAnnotations;

namespace ConferenceSystem.WebApi.ViewModel
{
    public sealed class NewCategory
    {
        [Required]
        public string Title { get; set; }
    }
}