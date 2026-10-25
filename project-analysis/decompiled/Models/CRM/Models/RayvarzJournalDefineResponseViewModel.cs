using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzJournalDefineResponseViewModel
{
	public string guid { get; set; }

	public bool? isSaved { get; set; }

	public List<RayvarzJournalEntitiesResponseViewModel> entities { get; set; }

	public List<RayvarzAPIValidationResultsViewModel> validationResults { get; set; }

	public bool? disposing { get; set; }
}
