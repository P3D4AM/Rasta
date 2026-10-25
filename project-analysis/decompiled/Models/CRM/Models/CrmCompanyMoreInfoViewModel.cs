using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyMoreInfoViewModel
{
	[Key]
	public int CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpEmail")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpEmail { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSpecialWordForCI")]
	public string cmpSpecialWordForCI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpUserName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPassword")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPassword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFOAccessLinkedCompany")]
	public bool? cmpFOAccessLinkedCompany { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMobile")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpMobile { get; set; }

	public string cmpSpecialWordForCI_Lang { get; set; }

	public bool? cmpIsDraft { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTicketAllowInCurrntCount")]
	public int? cmpTicketAllowInCurrntCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTicketAllowAddBeforeAnswerCount")]
	public int? cmpTicketAllowAddBeforeAnswerCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpIVRLinkRule")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpIVRLinkRule { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTicketCountCurrentWithStop")]
	public bool? cmpTicketCountCurrentWithStop { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpShpSettlementTypeId")]
	public int? cmpShpSettlementTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpShpSettlementCreditIssueType")]
	public int? cmpShpSettlementCreditIssueType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpShpSettlementCreditPerBuy")]
	public decimal? cmpShpSettlementCreditPerBuy { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpShpSettlementTotalCredit")]
	public decimal? cmpShpSettlementTotalCredit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpShpSettlementCreditRemainShow")]
	public bool? cmpShpSettlementCreditRemainShow { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCRMShopIsActive")]
	public bool? cmpCRMShopIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCRMShopActiveDate")]
	public string cmpCRMShopActiveDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFOIsActive")]
	public bool? cmpFOIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFOActiveDate")]
	public string cmpFOActiveDate { get; set; }

	public int? cmpFOActiveUserId { get; set; }

	public string cmpFOActiveUser { get; set; }

	public DateTime? cmpFOLoginExpireDate { get; set; }

	public string cmpFOLoginExpireDatePersian { get; set; }

	public int? cmpFOLoginExpireUserId { get; set; }

	public string cmpFOLoginExpireUser { get; set; }

	public string cmpFOInfo { get; set; }

	public string cmpFOInfoExtra { get; set; }

	public string cmpCIds { get; set; }
}
