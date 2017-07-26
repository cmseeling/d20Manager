using CampaignManager.Data.Enums;

namespace CampaignManager.Business.ViewModels
{
    public class CharacterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CampaignId { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public string Race { get; set; }
        public Size Size { get; set; }
        public string Gender { get; set; }
        public Alignment Alignment { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
    }
}
