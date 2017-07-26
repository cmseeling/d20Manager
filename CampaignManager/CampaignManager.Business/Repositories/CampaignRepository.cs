using CampaignManager.Business.Interfaces;
using CampaignManager.Data;
using CampaignManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CampaignManager.Business.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private CampaignContext _context;

        public CampaignRepository(CampaignContext context)
        {
            _context = context;
        }

        public void AddCampaign(Campaign campaign)
        {
            _context.Campaigns.Add(campaign);
        }

        public bool CampaignExists(int id)
        {
            return _context.Campaigns.Any(c => c.Id == id);
        }

        public void DeleteCampaign(Campaign campaign)
        {
            _context.Campaigns.Remove(campaign);
        }

        public Campaign GetCampaign(int id)
        {
            return GetCampaign(id, false);
        }

        public Campaign GetCampaign(int id, bool includeCharacters)
        {
            if(includeCharacters)
                return _context.Campaigns.Include(c=>c.Characters).FirstOrDefault(c => c.Id == id);

            return _context.Campaigns.FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Campaign> GetCampaigns()
        {
            return _context.Campaigns;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
