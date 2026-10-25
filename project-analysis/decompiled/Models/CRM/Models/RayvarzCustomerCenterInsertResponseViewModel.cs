using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzCustomerCenterInsertResponseViewModel
{
	public string guid { get; set; }

	public bool? isSaved { get; set; }

	public List<RayvarzCustomerCenterInsertEntitiesResponseViewModel> entities { get; set; }

	public List<RayvarzAPIValidationResultsViewModel> validationResults { get; set; }

	public bool? disposing { get; set; }
}
