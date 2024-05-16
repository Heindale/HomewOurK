using HomewOurK.Application.Interfaces;
using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomewOurK.Infrastructure.Services
{
	public class ProposalService : IProposalService
	{
		private IBaseEntityRepository<Proposal> _proposalRepository;

		public ProposalService(IBaseEntityRepository<Proposal> proposalRepository)
		{
			_proposalRepository = proposalRepository;
		}

		public bool AddProposal(Proposal proposal)
		{
			var proposals = _proposalRepository.GetAll();

			if (proposals.FirstOrDefault(p => p.GroupId == proposal.GroupId) == null
				|| proposals.FirstOrDefault(p => p.UserId == proposal.UserId) == null)
				return _proposalRepository.Add(proposal);
			return false;
		}

		public bool DeleteProposal(Proposal proposal)
		{
			var proposals = _proposalRepository.GetAll();

			if (proposals.FirstOrDefault(p => p.GroupId == proposal.GroupId) != null
				&& proposals.FirstOrDefault(p => p.UserId == proposal.UserId) != null)
				return _proposalRepository.Delete(proposal);
			return false;
		}

		public IEnumerable<Proposal> GetProposalsByGroupId(int groupId)
		{
			return _proposalRepository.Entities.Where(p => p.GroupId == groupId);
		}
	}
}
