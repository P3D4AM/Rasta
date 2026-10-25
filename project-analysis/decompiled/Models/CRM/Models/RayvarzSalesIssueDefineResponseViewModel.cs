using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzSalesIssueDefineResponseViewModel
{
	public string guid { get; set; }

	public bool? isSaved { get; set; }

	public List<RayvarzSalesIssueEntitiesResponseViewModel> entities { get; set; }

	public List<RayvarzAPIValidationResultsViewModel> validationResults { get; set; }
}
