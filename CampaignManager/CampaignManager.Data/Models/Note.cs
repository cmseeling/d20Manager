using System.ComponentModel.DataAnnotations;

namespace CampaignManager.Data.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
