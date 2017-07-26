using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignManager.Business.ViewModels
{
    public class CampaignViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CampaignWithCharactersViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CharacterViewModel> Characters { get; set; } = new List<CharacterViewModel>();
    }

    public class CreateCampaignViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }
    }

    public class EditCampaignViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
