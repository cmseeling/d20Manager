using CampaignManager.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignManager.Data.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        //need user link

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        [Required]
        [MaxLength(100)]
        public string Class { get; set; }

        //todo - figure out how multiclassing is going to work
        public int Level { get; set; }

        [Required]
        [MaxLength(50)]
        public string Race { get; set; }

        public Size Size { get; set; }

        [MaxLength(50)]
        public string Gender { get; set; }

        public Alignment Alignment { get; set; }

        [MaxLength(10)]
        public string Height { get; set; }

        [MaxLength(10)]
        public string Weight { get; set; }

        [Required]
        public int Strength { get; set; }

        [Required]
        public int Dexterity { get; set; }

        [Required]
        public int Constitution { get; set; }

        [Required]
        public int Intelligence { get; set; }

        [Required]
        public int Wisdom { get; set; }

        [Required]
        public int Charisma { get; set; }

        public ICollection<CharacterAbility> CharacterAbilities { get; set; } = new HashSet<CharacterAbility>();

        public ICollection<CharacterFeat> CharacterFeats { get; set; } = new HashSet<CharacterFeat>();

        public ICollection<CharacterItem> CharacterItems { get; set; } = new HashSet<CharacterItem>();
        
        public ICollection<CharacterSkill> CharacterSkills { get; set; } = new HashSet<CharacterSkill>();

        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
    }
}
