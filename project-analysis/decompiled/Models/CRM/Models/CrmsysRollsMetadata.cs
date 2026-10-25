using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmsysRollsMetadata
{
	[Key]
	public int ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RollName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Description")]
	public string Description { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LimitPreOrderDiscountActive")]
	public bool? LimitPreOrderDiscountActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LimitPreOrderDiscountPercent")]
	public decimal? LimitPreOrderDiscountPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LimitOrderDiscountActive")]
	public bool? LimitOrderDiscountActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LimitOrderDiscountPercent")]
	public decimal? LimitOrderDiscountPercent { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
