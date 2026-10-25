using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSCurrencyUnitRateViewModel
{
	[Key]
	public int CurrencyUnitRateId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CurrUnitRateSrcCurrencyUnitId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int SrcCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CurrUnitRateDestCurrencyUnitId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int DestCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CurrUnitRateCurrencyRate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public double CurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CurrUnitRateDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string RateDatePersian { get; set; }
}
