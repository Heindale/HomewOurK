using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomewOurK.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProposalsController : ControllerBase
	{
		IProposalService _proposalService;

		public ProposalsController(IProposalService proposalService)
		{
			_proposalService = proposalService;
		}

		[HttpGet]
		public IActionResult GetProposals(int groupId)
		{
			var proposals = _proposalService.GetProposalsByGroupId(groupId);

			if (proposals.Any())
				return Ok(proposals);
			return NotFound("No proposals was found for the group with id = " + groupId);
		}

		[HttpPost]
		public IActionResult AddProposal(Proposal proposal)
		{
			proposal.Id = 0;
			if (_proposalService.AddProposal(proposal))
				return Ok(proposal);
			return BadRequest("The proposal has not been added");
		}

		[HttpDelete]
		public IActionResult DeleteProposal(int id)
		{
			if (_proposalService.DeleteProposal(new Proposal { Id = id }))
				return Ok(new Proposal { Id = id });
			return BadRequest("The proposal has not been deleted");
		}
	}
}
