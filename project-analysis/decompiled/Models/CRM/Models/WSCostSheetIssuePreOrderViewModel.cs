using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSCostSheetIssuePreOrderViewModel
{
	public int CostSheetId { get; set; }

	public string PreOrderPayments { get; set; }

	public string PreOrderCommissions { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrjInquiryNum")]
	public string ctshPrjInquiryNum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrjNumRef")]
	public string ctshPrjNumRef { get; set; }

	public int? PreOrderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "ctshPordCompanyId")]
	public int? pordCompanyId { get; set; }

	public string pordCompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCompanyNumebr")]
	public int? pordCompanyNumber { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "ctshPordCompanyPersonId")]
	public int? pordCompanyPersonId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "ctshPordProjectId")]
	public int? pordProjectId { get; set; }

	public string pordProject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordReferUser")]
	public int? pordReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordDeliveryDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string pordDeliveryDate { get; set; }

	public DateTime? pordDeliveryDateTime { get; set; }

	public string pordDeliveryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordDeliveryTermId")]
	public int? pordDeliveryTermId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "ctshPordCurrencyUnitId")]
	public int? pordCurrencyUnitId { get; set; }

	public string pordCostSheetIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordTypeId")]
	public int? pordTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPreOrderOprId")]
	public int? PreOrderOprId { get; set; }

	public string PordNumRefFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordPayImportDate")]
	public string pordpayImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordPayType")]
	public int? pordpayTypeId { get; set; }

	public string pordpayType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordPayAmount")]
	public decimal? pordpayAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommDate")]
	public string pordCommDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommUserId")]
	public int? pordCommUserId { get; set; }

	public string pordCommUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommBaseAmount")]
	public decimal? pordCommBaseAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommAmount")]
	public decimal? pordCommAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommAmountCurrUnId")]
	public int? pordCommAmountCurrUnId { get; set; }

	public string pordCommAmountCurrUn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPordCommAmountCurrencyRate")]
	public double? pordCommAmountCurrencyRate { get; set; }
}
