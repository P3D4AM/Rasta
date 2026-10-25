using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderSettingViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "OrdSettingGrossProfitFormula")]
	public string ordGrossProfitFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdSettingMoneySleepFormula")]
	public string ordMoneySleepFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdSettingSaleNetProfitFormula")]
	public string ordSaleNetProfitFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdSettingNetProfitFormula")]
	public string ordNetProfitFormula { get; set; }
}
