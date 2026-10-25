using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzAPIResponseViewModel
{
	public string guid { get; set; }

	public bool? isSaved { get; set; }

	public List<RayvarzAPIValidationResultsViewModel> validationResults { get; set; }
}
