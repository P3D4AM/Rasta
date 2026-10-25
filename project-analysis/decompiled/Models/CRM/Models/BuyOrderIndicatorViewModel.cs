using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class BuyOrderIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorDate")]
	public string BordIndicatorDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorFDate")]
	public string BordIndicatorFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorTDate")]
	public string BordIndicatorTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorFOrderDate")]
	public string BordIndicatorFOrderDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorTOrderDate")]
	public string BordIndicatorTOrderDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorMonth")]
	public string BordIndicatorMonth { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorCompanyId")]
	public string BordIndicatorCompanyId { get; set; }

	public string BordIndicatorCompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorBordNumber")]
	public string BordIndicatorBordNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorBordOrderNumber")]
	public string BordIndicatorBordOrderNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorStatusId")]
	public string BordIndicatorStatusId { get; set; }

	public string BordIndicatorStatusIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorFirstRegisterUserId")]
	public string BordIndicatorFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorReferUserId")]
	public string BordIndicatorReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorSuppUserId")]
	public string BordIndicatorSuppUserId { get; set; }

	public string BordIndicatorSuppUserIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorPrdFirstGroupId")]
	public string BordIndicatorPrdFirstGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorPrdSecondGroupId")]
	public string BordIndicatorPrdSecondGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorPrdId")]
	public string BordIndicatorPrdId { get; set; }

	public string BordIndicatorPrdIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorBordOprId")]
	public string BordIndicatorBordOprId { get; set; }

	public string BordIndicatorBordOprIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorOtherFieldName")]
	public string BordIndicatorOtherFieldName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorOtherFieldValueLikely")]
	public bool BordIndicatorOtherFieldValueLikelyBoolean { get; set; }

	public string BordIndicatorOtherFieldValueLikely { get; set; }

	public string BordIndicatorOtherFieldValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorBordAmount")]
	public string BordIndicatorBordAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorPrintFormatId")]
	public string BordIndicatorPrintFormatId { get; set; }

	public string BordIndicatorOrderVerifiedStatusId { get; set; }

	public string BordIndicatorSettlementTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorHaveLinkAcc")]
	public string BordIndicatorHaveLinkAcc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorVerified")]
	public string BordIndicatorVerified { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorVerificationWorkflowId")]
	public string BordIndicatorVerificationWorkflowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorVerificationWorkflowStepId")]
	public string BordIndicatorVerificationWorkflowStepId { get; set; }

	public int? LinkAccSettingDBId { get; set; }

	public string BordIndicatorFirstRegisterUserIdMulti { get; set; }

	public string BordIndicatorReferUserIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorFPayDocDateTemp")]
	public string BordIndicatorFPayDocDateTemp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorTPayDocDateTemp")]
	public string BordIndicatorTPayDocDateTemp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorWrhsId")]
	public string BordIndicatorWrhsId { get; set; }

	public string BordIndicatorWrhsIds { get; set; }

	public string BordIndicatorPrdSpecsJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCurrencyUnitId")]
	public string BordCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorFacilityCompanyId")]
	public string BordFacilityCmpId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BordIndicatorReqCompanyId")]
	public string BordReqCmpId { get; set; }
}
