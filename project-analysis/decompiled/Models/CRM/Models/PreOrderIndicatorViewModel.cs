using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PreOrderIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorDate")]
	public string PordIndicatorDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorFDate")]
	public string PordIndicatorFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorTDate")]
	public string PordIndicatorTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorMonth")]
	public string PordIndicatorMonth { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorCompanyId")]
	public string PordIndicatorCompanyId { get; set; }

	public string PordIndicatorCompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPreOrderNumber")]
	public string PordIndicatorPreOrderNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorStatusId")]
	public string PordIndicatorStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorFirstRegisterUserId")]
	public string PordIndicatorFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorReferUserId")]
	public string PordIndicatorReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPrdFirstGroupId")]
	public string PordIndicatorPrdFirstGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPrdSecondGroupId")]
	public string PordIndicatorPrdSecondGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPrdId")]
	public string PordIndicatorPrdId { get; set; }

	public string PordIndicatorPrdIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPreOrderOprId")]
	public string PordIndicatorPreOrderOprId { get; set; }

	public string PordIndicatorPreOrderOprIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorOtherFieldName")]
	public string PordIndicatorOtherFieldName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorOtherFieldValueLikely")]
	public bool PordIndicatorOtherFieldValueLikelyBoolean { get; set; }

	public string PordIndicatorOtherFieldValueLikely { get; set; }

	public string PordIndicatorOtherFieldValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorVerified")]
	public string PordIndicatorVerified { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorHaveOrder")]
	public string PordIndicatorHaveOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorVerificationWorkflow")]
	public string PordIndicatorVerificationWorkflowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorVerificationWorkflowStep")]
	public string PordIndicatorVerificationWorkflowStepId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPordTypeId")]
	public string PordIndicatorPordTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPordDeliveryTermId")]
	public string PordIndicatorPordDeliveryTermId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorSellerId")]
	public string PordIndicatorSellerId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorTotalAmount")]
	public string PordIndicatorTotalAmount { get; set; }

	public string PordIndicatorTotalAmountTo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPreOrderSaleCenterId")]
	public string PordIndicatorPreOrderSaleCenterId { get; set; }

	public string PordIndicatorPreOrderSaleCenterIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorFDate")]
	public string PordIndicatorFExpireDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorTDate")]
	public string PordIndicatorTExpireDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorHaveLinkAcc")]
	public string PordIndicatorHaveLinkAcc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPrdColorId")]
	public string PordIndicatorPrdColorId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPrdSize")]
	public string PordIndicatorPrdSize { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorPrdDesign")]
	public string PordIndicatorPrdDesign { get; set; }

	public string PordIndicatorStatusIdMulti { get; set; }

	public string PordIndicatorFirstRegisterUserIdMulti { get; set; }

	public string PordIndicatorReferUserIdMulti { get; set; }

	public string PordIndicatorSellerIdMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorFDeadlineDate")]
	public string PordIndicatorFDeadlineDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorTDeadlineDate")]
	public string PordIndicatorTDeadlineDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorFPayDocDateTemp")]
	public string PordIndicatorFPayDocDateTemp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorTPayDocDateTemp")]
	public string PordIndicatorTPayDocDateTemp { get; set; }

	public int? LinkAccSettingDBId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorWrhsId")]
	public string PordIndicatorWrhsId { get; set; }

	public string PordIndicatorWrhsIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorFDeliveryDate")]
	public string PordIndicatorFDeliveryDateStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorFDeliveryDate")]
	public DateTime? PordIndicatorFDeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorTDeliveryDate")]
	public string PordIndicatorTDeliveryDateStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorTDeliveryDate")]
	public DateTime? PordIndicatorTDeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorFDeliveryTime")]
	public string PordIndicatorFDeliveryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIndicatorTDeliveryTime")]
	public string PordIndicatorTDeliveryTime { get; set; }

	public string PordIndicatorPrdSpecsJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordCurrencyUnitId")]
	public string PordCurrencyUnitId { get; set; }
}
