using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSDiscountStrategyLanguageViewModel
{
	[Key]
	public int DiscountStrategyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisStTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DisStTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisStSystemPartId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int DisStSystemPartId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisStDiscountStrategyTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int DisStDiscountStrategyTypeId { get; set; }

	public string DisStTypeValues { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisStExpireDatePersian")]
	public string DisStExpireDatePersian { get; set; }

	public DateTime? DisStExpireDate { get; set; }

	public string DisStTitle_Lang { get; set; }
}
