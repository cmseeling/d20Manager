using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignManager.Data.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(10)]
        public string Value { get; set; }

        [MaxLength(10)]
        public string Weight { get; set; }

        public ICollection<CharacterItem> CharacterItems { get; set; } = new HashSet<CharacterItem>();
    }
}
