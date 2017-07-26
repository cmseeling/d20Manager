using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignManager.Data.Models
{
    public class Feat
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<CharacterFeat> CharacterFeats { get; set; } = new HashSet<CharacterFeat>();
    }
}
