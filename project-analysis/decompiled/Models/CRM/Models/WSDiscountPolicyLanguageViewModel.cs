using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSDiscountPolicyLanguageViewModel
{
	[Key]
	public int DiscountPolicyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DPSystemPartId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int DPSystemPartId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DPTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DPTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DPDiscountPercent")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal DPDiscountPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DPExpireDate")]
	public string DPExpireDatePersian { get; set; }

	public DateTime? DPExpireDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DPIsActive")]
	public bool? DPIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DPOrderView")]
	public int? DPOrderView { get; set; }

	public string DPFormulaJson { get; set; }

	public string DPFormulaJsonByName { get; set; }

	public string DPPrdExceptionJson { get; set; }

	public string DPPrdExceptionJsonByName { get; set; }

	public string DPTitle_Lang { get; set; }
}
