using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignManager.Data.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Ranks { get; set; }

        public ICollection<CharacterSkill> CharacterSkills { get; set; } = new HashSet<CharacterSkill>();
    }
}
