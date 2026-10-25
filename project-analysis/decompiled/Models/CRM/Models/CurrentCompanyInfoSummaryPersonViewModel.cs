using System.Collections.Generic;

namespace CRM.Models;

public class CurrentCompanyInfoSummaryPersonViewModel
{
	public List<CrmCompanyPersonViewModel> Persons { get; set; }

	public List<CrmPersonPicture> PrsPicture { get; set; }
}
