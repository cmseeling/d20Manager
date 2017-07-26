using CampaignManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignManager.Business.Interfaces
{
    public interface ICampaignRepository
    {
        IQueryable<Campaign> GetCampaigns();

        Campaign GetCampaign(int id);

        bool CampaignExists(int id);

        void AddCampaign(Campaign campaign);

        void DeleteCampaign(Campaign campaign);

        bool Save();
    }
}
