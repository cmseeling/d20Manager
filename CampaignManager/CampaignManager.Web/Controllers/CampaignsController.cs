using AutoMapper;
using CampaignManager.Business.Interfaces;
using CampaignManager.Business.ViewModels;
using CampaignManager.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManager.Web.Controllers
{
    [Route("api/[controller]")]
    public class CampaignsController : Controller
    {
        ICampaignRepository _repository;

        public CampaignsController(ICampaignRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetCampaigns()
        {
            var campaigns = _repository.GetCampaigns();
            var results = Mapper.Map<IEnumerable<CampaignViewModel>>(campaigns);
            return Ok(results);
        }

        [HttpGet("{id}", Name = "GetCampaign")]
        public IActionResult GetCampaign(int id, bool includeCharacters = false)
        {
            var campaign = _repository.GetCampaign(id, includeCharacters);
            if (campaign == null)
                return NotFound();

            if(includeCharacters)
            {
                var resultWithCharacters = Mapper.Map<CampaignWithCharactersViewModel>(campaign);
                return Ok(resultWithCharacters);
            }

            var result = Mapper.Map<CampaignViewModel>(campaign);

            return Ok(result);
        }

        [HttpPost("")]
        public IActionResult CreateCampaign([FromBody]CreateCampaignViewModel campaignViewModel)
        {
            if (campaignViewModel == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newCampaign = Mapper.Map<Campaign>(campaignViewModel);

            _repository.AddCampaign(newCampaign);
            if (!_repository.Save())
                return StatusCode(500, "A problem happened when handling your request.");

            var createdCampaign = Mapper.Map<CampaignViewModel>(newCampaign);
            return CreatedAtRoute("GetCampaign", new { id = createdCampaign.Id }, createdCampaign);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCampaign(int id, [FromBody]EditCampaignViewModel campaignViewModel)
        {
            if (campaignViewModel == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var campaignModel = _repository.GetCampaign(id);
            if (campaignModel == null)
                return NotFound();

            Mapper.Map(campaignViewModel, campaignModel);

            if (!_repository.Save())
                return StatusCode(500, "A problem happened when handling your request.");

            return NoContent();

        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateCampaign(int id, [FromBody] JsonPatchDocument<EditCampaignViewModel> patchDoc)
        {
            //checking for valid patchDoc
            if (patchDoc == null)
                return BadRequest();

            //get the model from the database
            var campaignModel = _repository.GetCampaign(id);
            if (campaignModel == null)
                return NotFound();

            //create a new instance of the edit view model
            var viewModelToPatch = Mapper.Map<EditCampaignViewModel>(campaignModel);

            //apply the patch operations to the view model
            patchDoc.ApplyTo(viewModelToPatch, ModelState);

            //check the new viewmodel state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            TryValidateModel(viewModelToPatch);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //map changes to the database model and save
            Mapper.Map(viewModelToPatch, campaignModel);

            if (!_repository.Save())
                return StatusCode(500, "A problem happened when handling your request.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCampaign(int id)
        {
            var campaignModel = _repository.GetCampaign(id);
            if (campaignModel == null)
                return NotFound();

            _repository.DeleteCampaign(campaignModel);

            if (!_repository.Save())
                return StatusCode(500, "A problem happened when handling your request.");

            return NoContent();
        }
    }
}
