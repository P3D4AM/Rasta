using System.Collections.Generic;

namespace CRM.Models;

public class CurrentCompanyPersonsInSummaryViewModel
{
	public List<CrmCompanyPersonViewModel> Persons { get; set; }

	public List<CrmCompanyPersonViewModel> PersonsInSummary { get; set; }

	public List<CRMspDySelectFormsMenuWithSysPartId_Result> PersonDyFormInSummary { get; set; }
}
