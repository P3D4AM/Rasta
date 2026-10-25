using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzJournalMainDefineViewModel
{
	public string RaySystemId { get; set; }

	public List<RayvarzJournalDefineViewModel> Journals { get; set; }

	public bool? SaveToCash { get; set; }

	public bool? IsComplete { get; set; }
}
