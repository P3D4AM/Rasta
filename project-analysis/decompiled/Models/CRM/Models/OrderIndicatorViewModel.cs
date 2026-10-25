using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class OrderIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorDate")]
	public string OrdIndicatorDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorFDate")]
	public string OrdIndicatorFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorTDate")]
	public string OrdIndicatorTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorMonth")]
	public string OrdIndicatorMonth { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorCompanyId")]
	public string OrdIndicatorCompanyId { get; set; }

	public string OrdIndicatorCompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorOrderNumber")]
	public string OrdIndicatorOrderNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorStatusId")]
	public string OrdIndicatorStatusId { get; set; }

	public string OrdIndicatorStatusIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorFirstRegisterUserId")]
	public string OrdIndicatorFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorReferUserId")]
	public string OrdIndicatorReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorPrdFirstGroupId")]
	public string OrdIndicatorPrdFirstGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorPrdSecondGroupId")]
	public string OrdIndicatorPrdSecondGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorPrdId")]
	public string OrdIndicatorPrdId { get; set; }

	public string OrdIndicatorPrdIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorOrderOprId")]
	public string OrdIndicatorOrderOprId { get; set; }

	public string OrdIndicatorOrderOprIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorOtherFieldName")]
	public string OrdIndicatorOtherFieldName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorOtherFieldValueLikely")]
	public bool OrdIndicatorOtherFieldValueLikelyBoolean { get; set; }

	public string OrdIndicatorOtherFieldValueLikely { get; set; }

	public string OrdIndicatorOtherFieldValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorOrderAmount")]
	public string OrdIndicatorOrderAmount { get; set; }

	public string OrdIndicatorOrderAmountTo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorOrderVerifiedStatusId")]
	public string OrdIndicatorOrderVerifiedStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorPrintFormatId")]
	public string OrdIndicatorPrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorSettlementTypeId")]
	public string OrdIndicatorSettlementTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorDeliveryTermId")]
	public string OrdIndicatorDeliveryTermId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorVerificationWorkflow")]
	public string OrdIndicatorVerificationWorkflowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorVerificationWorkflowStep")]
	public string OrdIndicatorVerificationWorkflowStepId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorSellerId")]
	public string OrdIndicatorSellerId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorTracing")]
	public string OrdIndicatorTracing { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorSaleCenterId")]
	public string OrdIndicatorSaleCenterId { get; set; }

	public string OrdIndicatorSaleCenterIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorHaveLinkAcc")]
	public string OrdIndicatorHaveLinkAcc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorHaveTsp")]
	public string OrdIndicatorHaveTsp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorTspStatusResult")]
	public string OrdIndicatorTspStatusResult { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorPrdColorId")]
	public string OrdIndicatorPrdColorId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorPrdSize")]
	public string OrdIndicatorPrdSize { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorPrdDesign")]
	public string OrdIndicatorPrdDesign { get; set; }

	public string OrdIndicatorFirstRegisterUserIdMulti { get; set; }

	public string OrdIndicatorReferUserIdMulti { get; set; }

	public string OrdIndicatorSellerIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorFDeadlineDate")]
	public string OrdIndicatorFDeadlineDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorTDeadlineDate")]
	public string OrdIndicatorTDeadlineDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorFPayDocDateTemp")]
	public string OrdIndicatorFPayDocDateTemp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorTPayDocDateTemp")]
	public string OrdIndicatorTPayDocDateTemp { get; set; }

	public int? LinkAccSettingDBId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorWrhsId")]
	public string OrdIndicatorWrhsId { get; set; }

	public string OrdIndicatorWrhsIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorHaveDoc")]
	public int? OrdIndicatorHaveDoc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorFDeliveryDate")]
	public string OrdIndicatorFDeliveryDateStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorFDeliveryDate")]
	public DateTime? OrdIndicatorFDeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorTDeliveryDate")]
	public string OrdIndicatorTDeliveryDateStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorTDeliveryDate")]
	public DateTime? OrdIndicatorTDeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorFDeliveryTime")]
	public string OrdIndicatorFDeliveryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdIndicatorTDeliveryTime")]
	public string OrdIndicatorTDeliveryTime { get; set; }

	public string OrdIndicatorPrdSpecsJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordCurrencyUnitId")]
	public string OrdCurrencyUnitId { get; set; }
}
