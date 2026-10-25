using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class OrderPaymentIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorDate")]
	public string OrdPayIndicatorDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorFDate")]
	public string OrdPayIndicatorFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorTDate")]
	public string OrdPayIndicatorTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorMonth")]
	public string OrdPayIndicatorMonth { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorCompanyId")]
	public string OrdPayIndicatorCompanyId { get; set; }

	public string OrdPayIndicatorCompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorOrderNumber")]
	public string OrdPayIndicatorOrderNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorTypeId")]
	public string OrdPayIndicatorTypeId { get; set; }

	public string OrdPayIndicatorTypeIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorAmount")]
	public decimal OrdPayIndicatorAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorFDocDate")]
	public string OrdPayIndicatorFDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorTDocDate")]
	public string OrdPayIndicatorTDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorDocNumber")]
	public string OrdPayIndicatorDocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorDocAmount")]
	public decimal OrdPayIndicatorDocAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorDescription")]
	public string OrdPayIndicatorDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorFirstRegisterUserId")]
	public string OrdPayIndicatorFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorUserId")]
	public string OrdPayIndicatorUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorReferUserId")]
	public string OrdPayIndicatorReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorDeActive")]
	public string OrdPayIndicatorDeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorHaveLinkAcc")]
	public string OrdPayIndicatorHaveLinkAcc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorIsVerified")]
	public string OrdPayIndicatorIsVerified { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdPayIndicatorOrderOprId")]
	public string OrdPayIndicatorOrderOprId { get; set; }

	public int? LinkAccSettingDBId { get; set; }
}
