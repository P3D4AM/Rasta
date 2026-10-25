using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PreOrderPaymentIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorDate")]
	public string PordPayIndicatorDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorFDate")]
	public string PordPayIndicatorFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorTDate")]
	public string PordPayIndicatorTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorMonth")]
	public string PordPayIndicatorMonth { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorCompanyId")]
	public string PordPayIndicatorCompanyId { get; set; }

	public string PordPayIndicatorCompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorPreOrderNumber")]
	public string PordPayIndicatorPreOrderNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorTypeId")]
	public string PordPayIndicatorTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorAmount")]
	public decimal PordPayIndicatorAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorFDocDate")]
	public string PordPayIndicatorFDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorTDocDate")]
	public string PordPayIndicatorTDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorDocNumber")]
	public string PordPayIndicatorDocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorDocAmount")]
	public decimal PordPayIndicatorDocAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorDescription")]
	public string PordPayIndicatorDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorFirstRegisterUserId")]
	public string PordPayIndicatorFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorUserId")]
	public string PordPayIndicatorUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorReferUserId")]
	public string PordPayIndicatorReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorDeActive")]
	public string PordPayIndicatorDeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorHaveLinkAcc")]
	public string PordPayIndicatorHaveLinkAcc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordPayIndicatorIsVerified")]
	public string PordPayIndicatorIsVerified { get; set; }

	public int? LinkAccSettingDBId { get; set; }
}
