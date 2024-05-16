using HomewOurK.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomewOurK.Application.Interfaces
{
	public interface IProposalService
	{
		IEnumerable<Proposal> GetProposalsByGroupId(int groupId);

		bool AddProposal(Proposal proposal);

		bool DeleteProposal(Proposal proposal);
	}
}
