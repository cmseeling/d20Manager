using CampaignManager.Data.Models;
using System.Linq;

namespace CampaignManager.Business.Interfaces
{
    public interface ICampaignRepository
    {
        IQueryable<Campaign> GetCampaigns();

        Campaign GetCampaign(int id);

        Campaign GetCampaign(int id, bool includeCharacters);

        bool CampaignExists(int id);

        void AddCampaign(Campaign campaign);

        void DeleteCampaign(Campaign campaign);

        bool Save();
    }
}
