using System.Collections.Generic;

namespace CRM.Models;

public class CurrentCompanyAndPersonsPictureInSummaryViewModel
{
	public string CompanyLogo { get; set; }

	public List<CurrentPersonsPictureInSummaryViewModel> PersonsPicture { get; set; }
}
