using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class BuyOrderPaymentIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorDate")]
	public string BordPayIndicatorDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorFDate")]
	public string BordPayIndicatorFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorTDate")]
	public string BordPayIndicatorTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorMonth")]
	public string BordPayIndicatorMonth { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorCompanyId")]
	public string BordPayIndicatorCompanyId { get; set; }

	public string BordPayIndicatorCompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorBuyOrderNumber")]
	public string BordPayIndicatorBuyOrderNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorTypeId")]
	public string BordPayIndicatorTypeId { get; set; }

	public string BordPayIndicatorTypeIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorAmount")]
	public decimal BordPayIndicatorAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorFDocDate")]
	public string BordPayIndicatorFDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorTDocDate")]
	public string BordPayIndicatorTDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorDocNumber")]
	public string BordPayIndicatorDocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorDocAmount")]
	public decimal BordPayIndicatorDocAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorDescription")]
	public string BordPayIndicatorDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorFirstRegisterUserId")]
	public string BordPayIndicatorFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorUserId")]
	public string BordPayIndicatorUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorReferUserId")]
	public string BordPayIndicatorReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorDeActive")]
	public string BordPayIndicatorDeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorHaveLinkAcc")]
	public string BordPayIndicatorHaveLinkAcc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordPayIndicatorIsVerified")]
	public string BordPayIndicatorIsVerified { get; set; }

	public int? LinkAccSettingDBId { get; set; }
}
