using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CostSheetIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "CtshIndicatorDate")]
	public string CtshIndicatorDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CtshIndicatorFDate")]
	public string CtshIndicatorFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CtshIndicatorTDate")]
	public string CtshIndicatorTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CtshIndicatorNumber")]
	public string CtshIndicatorNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CtshIndicatorCompanyId")]
	public string CtshIndicatorCompanyId { get; set; }

	public string CtshIndicatorCompanyName { get; set; }
}
