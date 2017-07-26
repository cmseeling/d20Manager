using CampaignManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignManager.Data
{
    public static class CampaignContextExtensions
    {
        public static void EnsureSeedDataForContext(this CampaignContext context)
        {
            if(!context.Campaigns.Any())
            {
                var campaign = new Campaign()
                {
                    Name = "Search for the Holy Grail"
                };

                if(!context.Characters.Any())
                {
                    var character = new Character()
                    {
                        Name = "Arthur, Kinf of the Brits",
                        Class = "Fighter 1",
                        Race = "Human",
                        Strength = 10,
                        Dexterity = 10,
                        Constitution = 10,
                        Intelligence = 8,
                        Wisdom = 8,
                        Charisma = 12
                    };

                    campaign.Characters = new List<Character>() { character };
                }

                context.Campaigns.Add(campaign);
                context.SaveChanges();
            }
        }
    }
}
