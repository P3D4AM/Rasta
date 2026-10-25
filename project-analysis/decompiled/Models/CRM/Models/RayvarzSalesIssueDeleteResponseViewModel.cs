using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzSalesIssueDeleteResponseViewModel
{
	public string guid { get; set; }

	public bool? isSaved { get; set; }

	public List<RayvarzSalesIssueDeleteEntitiesResponseViewModel> entities { get; set; }

	public List<RayvarzAPIValidationResultsViewModel> validationResults { get; set; }
}
