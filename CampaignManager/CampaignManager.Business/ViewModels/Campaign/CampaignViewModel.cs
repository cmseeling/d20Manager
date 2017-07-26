using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CampaignManager.Business.ViewModels.Campaign
{
    public class CampaignViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
