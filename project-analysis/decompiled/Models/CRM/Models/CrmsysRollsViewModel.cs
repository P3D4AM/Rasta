using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmsysRollsViewModel
{
	[Key]
	public int ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RollName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollDescription")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LimitPreOrderDiscountActive")]
	public bool? LimitPreOrderDiscountActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LimitPreOrderDiscountActive")]
	public bool RollsLimitPreOrderDiscountActive
	{
		get
		{
			if (!LimitPreOrderDiscountActive.HasValue || !LimitPreOrderDiscountActive.GetValueOrDefault())
			{
				return false;
			}
			return true;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "LimitPreOrderDiscountPercent")]
	public decimal? LimitPreOrderDiscountPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LimitOrderDiscountActive")]
	public bool? LimitOrderDiscountActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LimitOrderDiscountActive")]
	public bool RollsLimitOrderDiscountActive
	{
		get
		{
			if (!LimitOrderDiscountActive.HasValue || !LimitOrderDiscountActive.GetValueOrDefault())
			{
				return false;
			}
			return true;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "LimitOrderDiscountPercent")]
	public decimal? LimitOrderDiscountPercent { get; set; }

	public int? LanguageID { get; set; }

	public string RollName_Lang { get; set; }

	public string Description_Lang { get; set; }

	public string RegisterDatePersian { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string AppType { get; set; }
}
