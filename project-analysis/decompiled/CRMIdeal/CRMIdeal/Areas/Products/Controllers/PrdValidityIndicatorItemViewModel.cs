using System.Collections.Generic;
using CRM.Models;

namespace CRMIdeal.Areas.Products.Controllers;

public class PrdValidityIndicatorItemViewModel
{
	public List<WSspSelectProductValidityIndicator_Result> Items { get; set; }

	public string CmpIds { get; set; }

	public string OprJson { get; set; }
}
