using System.Collections.Generic;
using CRM.Models;

namespace CRMIdeal.Areas.Products.Controllers;

public class PrdValidityIndicatorCmpEmailMobileItemViewModel
{
	public List<CRMspSelectCompanyEmailsAndMobilesFromProductValidityIndicator_Result> Items { get; set; }

	public string OprJson { get; set; }
}
