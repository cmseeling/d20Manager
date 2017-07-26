namespace CampaignManager.Data.Models
{
    public class CharacterAbility
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }

        public int AbilityId { get; set; }
        public Ability Ability { get; set; }
    }
}
