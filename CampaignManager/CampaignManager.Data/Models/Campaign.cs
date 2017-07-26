using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignManager.Data.Models
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Character> Characters { get; set; } = new HashSet<Character>();
    }
}
