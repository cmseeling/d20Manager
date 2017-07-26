namespace CampaignManager.Data.Models
{
    public class CharacterFeat
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }

        public int FeatId { get; set; }
        public Feat Feat { get; set; }
    }
}
