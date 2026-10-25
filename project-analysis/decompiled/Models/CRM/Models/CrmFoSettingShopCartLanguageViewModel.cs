using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoSettingShopCartLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpTransportationDefValue")]
	public decimal? ShpTransportationDefValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpTransportationFreeMinValueI")]
	public decimal? ShpTransportationFreeMinValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPrjTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpDefPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPrjcnvsStatusGroup")]
	public int? ShpDefPrjcnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefWH")]
	public int? ShpDefWHId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefCurrencyUnit")]
	public int? ShpDefCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordVerifierRequest")]
	public int? ShpDefPordVerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordVerifierRequestMsg")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpDefPordVerifierRequestMsg { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordExpireDayI")]
	public int? ShpDefPordExpireDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordCnvsTopic")]
	public int? ShpDefPordCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordCnvsDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpDefPordCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordCnvsReferUser")]
	public int? ShpDefPordCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordCnvsReferMultiUser")]
	public string ShpDefPordCnvsReferMultiUser { get; set; }

	public string ShpDefPordCnvsReferMultiUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordCnvsStatus")]
	public int? ShpDefPordCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordCnvsPriority")]
	public int? ShpDefPordCnvsPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrderOpr")]
	public int? ShpDefOrderOprId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdVerifierRequest")]
	public int? ShpDefOrdVerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdVerifierRequestMsg")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpDefOrdVerifierRequestMsg { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdpayType")]
	public int? ShpDefOrdpayTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdCnvsTopic")]
	public int? ShpDefOrdCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdCnvsDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpDefOrdCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdCnvsReferUser")]
	public int? ShpDefOrdCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdCnvsReferMultiUser")]
	public string ShpDefOrdCnvsReferMultiUser { get; set; }

	public string ShpDefOrdCnvsReferMultiUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdCnvsStatus")]
	public int? ShpDefOrdCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdCnvsPriority")]
	public int? ShpDefOrdCnvsPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpShowPayOnLineRdoBtn")]
	public bool? ShpShowPayOnLineRdoBtn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpCartDescriptionLbl")]
	[UIHint("RichText")]
	[AllowHtml]
	public string ShpCartDescriptionLbl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpCartDescriptionPlaceholder")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpCartDescriptionPlaceholder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpCartPayTypeId")]
	public string ShpCartPayTypeIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoCanEditPayAmount")]
	public bool? FoCanEditPayAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPrsAddressNotNull")]
	public bool? ShpPrsAddressNotNull { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDeliveryScheduleActive")]
	public bool? ShpDeliveryScheduleActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPrdDeliveryScheduleActive")]
	public bool? ShpPrdDeliveryScheduleActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPrdDeliveryScheduleActiveInBox")]
	public bool? ShpPrdDeliveryScheduleActiveInBox { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPrdDeliveryScheduleActiveInDetail")]
	public bool? ShpPrdDeliveryScheduleActiveInDetail { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDeliveryScheduleLimitMoveDay")]
	public int? ShpDeliveryScheduleLimitMoveDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpCartIssuePordAfterPayOnLine")]
	public bool? ShpCartIssuePordAfterPayOnLine { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordReferUser")]
	public int? ShpDefPordReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPordVerifyAfterIssue")]
	public bool? ShpPordVerifyAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordVerifyWorkFlow")]
	public int? ShpDefPordVerifyWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPordVerifyWorkFlowStartAfterIssue")]
	public bool? ShpPordVerifyWorkFlowStartAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordPayType")]
	public int? ShpDefPordPayTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPordSendSmsAfterIssue")]
	public bool? ShpPordSendSmsAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPordSendSmsAfterIssueGSM")]
	public bool? ShpPordSendSmsAfterIssueGSM { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendSmsAfterIssueGSMSet")]
	public int? ShpDefPordSendSmsAfterIssueGSMSetId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPordSendSmsAfterIssueWeb")]
	public bool? ShpPordSendSmsAfterIssueWeb { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendSmsAfterIssueProvider")]
	public int? ShpDefPordSendSmsAfterIssueProviderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendSmsAfterIssueNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpDefPordSendSmsAfterIssueNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendSmsAfterBodyIssuePatternFormula")]
	public string ShpDefPordSendSmsAfterIssueBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPordSendEmailAfterIssue")]
	public bool? ShpPordSendEmailAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendEmailAfterIssueSetting")]
	public int? ShpDefPordSendEmailAfterIssueSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendEmailAfterIssueUserInfo")]
	public int? ShpDefPordSendEmailAfterIssueUserInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendEmailAfterIssueSubjectPatternFormula")]
	public string ShpDefPordSendEmailAfterIssueSubjectPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendEmailAfterIssueBodyPatternFormula")]
	[UIHint("RichText")]
	[AllowHtml]
	public string ShpDefPordSendEmailAfterIssueBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpCartIssueOrdAfterPayOnLine")]
	public bool? ShpCartIssueOrdAfterPayOnLine { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdReferUser")]
	public int? ShpDefOrdReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpOrdVerifyAfterIssue")]
	public bool? ShpOrdVerifyAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdVerifyWorkFlow")]
	public int? ShpDefOrdVerifyWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpOrdVerifyWorkFlowStartAfterIssue")]
	public bool? ShpOrdVerifyWorkFlowStartAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpOrdSendSmsAfterIssue")]
	public bool? ShpOrdSendSmsAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpOrdSendSmsAfterIssueGSM")]
	public bool? ShpOrdSendSmsAfterIssueGSM { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendSmsAfterIssueGSMSet")]
	public int? ShpDefOrdSendSmsAfterIssueGSMSetId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpOrdSendSmsAfterIssueWeb")]
	public bool? ShpOrdSendSmsAfterIssueWeb { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendSmsAfterIssueProvider")]
	public int? ShpDefOrdSendSmsAfterIssueProviderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendSmsAfterIssueNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpDefOrdSendSmsAfterIssueNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendSmsAfterIssueBodyPatternFormula")]
	public string ShpDefOrdSendSmsAfterIssueBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpOrdSendEmailAfterIssue")]
	public bool? ShpOrdSendEmailAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendEmailAfterIssueSetting")]
	public int? ShpDefOrdSendEmailAfterIssueSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendEmailAfterIssueUserInfo")]
	public int? ShpDefOrdSendEmailAfterIssueUserInfoId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendEmailAfterIssueSubjectPatternFormula")]
	public string ShpDefOrdSendEmailAfterIssueSubjectPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendEmailAfterIssueBodyPatternFormula")]
	[UIHint("RichText")]
	[AllowHtml]
	public string ShpDefOrdSendEmailAfterIssueBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpOrdSendLinkAccAfterIssue")]
	public bool? ShpOrdSendLinkAccAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpShowDeliveryTerm")]
	public bool? ShpShowDeliveryTerm { get; set; }

	public string ShpDefPrjTitle_Lang { get; set; }

	public string ShpDefPordVerifierRequestMsg_Lang { get; set; }

	public string ShpDefPordCnvsDesc_Lang { get; set; }

	public string ShpDefOrdVerifierRequestMsg_Lang { get; set; }

	public string ShpDefOrdCnvsDesc_Lang { get; set; }

	[AllowHtml]
	public string ShpCartDescriptionLbl_Lang { get; set; }

	public string ShpCartDescriptionPlaceholder_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPrdDoneTimeSchedule")]
	public bool? ShpPrdDoneTimeScheduleActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpCartSettlementCreditActive")]
	public bool? ShpCartSettlementCreditActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefItemCalculateTax")]
	public bool? ShpDefItemCalculateTax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefItemTaxIndex")]
	public decimal? ShpDefItemTaxIndex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefItemTaxType")]
	public int? ShpDefItemTaxType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordCreditDuration")]
	public int? ShpDefPordCreditDurationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordPrintFormat")]
	public int? ShpDefPordPrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPordSendSmsAfterVerify")]
	public bool? ShpPordSendSmsAfterVerify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPordSendSmsAfterVerifyGSM")]
	public bool? ShpPordSendSmsAfterVerifyGSM { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendSmsAfterVerifyGSMSet")]
	public int? ShpDefPordSendSmsAfterVerifyGSMSetId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPordSendSmsAfterVerifyWeb")]
	public bool? ShpPordSendSmsAfterVerifyWeb { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendSmsAfterVerifyProvider")]
	public int? ShpDefPordSendSmsAfterVerifyProviderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendSmsAfterVerifyNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpDefPordSendSmsAfterVerifyNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordSendSmsAfterVerifyBodyPatternFormula")]
	public string ShpDefPordSendSmsAfterVerifyBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdPrintFormat")]
	public int? ShpDefOrdPrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpOrdSendSmsAfterVerify")]
	public bool? ShpOrdSendSmsAfterVerify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpOrdSendSmsAfterVerifyGSM")]
	public bool? ShpOrdSendSmsAfterVerifyGSM { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendSmsAfterVerifyGSMSet")]
	public int? ShpDefOrdSendSmsAfterVerifyGSMSetId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpOrdSendSmsAfterVerifyWeb")]
	public bool? ShpOrdSendSmsAfterVerifyWeb { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendSmsAfterVerifyProvider")]
	public int? ShpDefOrdSendSmsAfterVerifyProviderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendSmsAfterVerifyNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpDefOrdSendSmsAfterVerifyNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdSendSmsAfterVerifyBodyPatternFormula")]
	public string ShpDefOrdSendSmsAfterVerifyBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpCanSaveOnlinePaymentAfterVerify")]
	public bool? ShpCanSaveOnlinePaymentAfterVerify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPrjStarterUser")]
	public int? ShpDefPrjStarterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPrjStarterUser")]
	public string ShpDefPrjStarterUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPrjNewProjectOnCart")]
	public bool? ShpDefPrjNewProjectOnCart { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpTransportationVisible")]
	public bool? ShpTransportationVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpToleranceVisible")]
	public bool? ShpToleranceVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpTolerancePercent")]
	public decimal? ShpTolerancePercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpToleranceLinkedPrd")]
	public int? ShpToleranceLinkedPrdId { get; set; }

	public string ShpToleranceLinkedPrd { get; set; }

	public bool? ShpToleranceLinkedPrdAutoCalcPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefPordCnvsStatusResult")]
	public int? ShpDefPordCnvsStatusResultId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefOrdCnvsStatusResult")]
	public int? ShpDefOrdCnvsStatusResultId { get; set; }
}
