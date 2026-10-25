using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSProductPriceGroupLanguageViewModel
{
	[Key]
	public int ProductPriceGroupID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoItemTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ProductPriceGroupName { get; set; }

	public string ProductPriceGroupDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoOrderView")]
	public int? OrderView { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPDefaultPriceGroup")]
	public bool? SHPDefaultPriceGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPPriceGroupVisible")]
	public bool? SHPPriceGroupVisible { get; set; }

	public string ProductPriceGroupName_Lang { get; set; }
}
