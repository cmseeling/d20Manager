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

            }
        }
    }
}
