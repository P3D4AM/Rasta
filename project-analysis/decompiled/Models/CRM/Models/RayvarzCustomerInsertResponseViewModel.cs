using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzCustomerInsertResponseViewModel
{
	public string guid { get; set; }

	public bool? isSaved { get; set; }

	public List<RayvarzCustomerEntitiesResponseViewModel> entities { get; set; }

	public List<RayvarzAPIValidationResultsViewModel> validationResults { get; set; }
}
