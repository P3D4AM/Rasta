using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSProductsLanguageViewModel
{
	[Key]
	public int ProductID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdGroupID")]
	public int PrdGroupID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCode")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdLatinName")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdLatinName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdType")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDesign")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdDesign { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSize")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdSize { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdColorId")]
	public int? PrdColorId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdUnitId")]
	public int? PrdUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdMinQty")]
	public int? PrdMinQty { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdMaxQty")]
	public int? PrdMaxQty { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSleepDay")]
	public int? PrdSleepDay { get; set; }

	public string PrdFirstSerial { get; set; }

	public string PrdSecondSerial { get; set; }

	public string PrdThirdSerial { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdBarCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdFirstBarcode { get; set; }

	public string PrdSecondBarcode { get; set; }

	public string PrdThirdBarcode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDescription")]
	[MaxLength(12000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(12000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdDescription { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdBarCode")]
	public string PrdBarCode { get; set; }

	public int? PrdBarCodeTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoNumBarcode")]
	public string PrdAutoNumBarcode { get; set; }

	public int? PrdAutoNumBarCodeTypeId { get; set; }

	public string PrdAutoCharBarcode { get; set; }

	public int? prdAutoCharBarCodeTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdModel")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdModel { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdInactiveInSale")]
	public bool? PrdInactiveInSale { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdInactiveInBuy")]
	public bool? PrdInactiveInBuy { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCommissionDisable")]
	public bool? PrdCommissionDisable { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCommissionPercentRate")]
	public double? PrdCommissionPercentRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdIsDefault")]
	public bool? PrdIsDefault { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdInActive")]
	public bool? PrdInActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdKind")]
	public int? PrdKind { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDefQuantity")]
	public string PrdDefQuantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdJustDefQuantity")]
	public bool? PrdJustDefQuantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdMinQuantity")]
	public double? PrdMinQuantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdMaxQuantity")]
	public double? PrdMaxQuantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdManufacturerName")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdManufacturerName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdManufacturerCode")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdManufacturerCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdLinkAccPrdGroupIdStr")]
	public string PrdLinkAccPrdGroupIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSendToAccLink")]
	public bool? SendToAcc { get; set; }

	public int? PrdLinkAccPrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdLinkAccPrdCode")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdLinkAccPrdCode { get; set; }

	public string PrdLinkAccPrdIdStr { get; set; }

	public string PrdLinkAccData { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSendToAccLinkWithPrdPrice")]
	public bool? SendToAccWithPrdPrice { get; set; }

	public bool? SendPrdGroupToAcc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdIVRLink")]
	public bool? PrdIVRLink { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdIVRLinkRule")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdIVRLinkRule { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdIVRLinkDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdIVRLinkDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidity")]
	public bool? PrdValidity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityDay")]
	public int? PrdValidityDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityTime")]
	public string PrdValidityTime { get; set; }

	public int? PrdValidityTimeHour { get; set; }

	public int? PrdValidityTimeMinute { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdUnitIdI")]
	public int? PrdUnitIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdUnitIRate")]
	public double? PrdUnitIRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdUnitIRateCalcAuto")]
	public bool? PrdUnitIRateCalcAuto { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdQtyNoFCR")]
	public bool? PrdQtyNoFCR { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdMustFullTracingCode")]
	public bool? PrdMustFullTracingCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSingleItem")]
	public bool? PrdSingleItem { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityCount")]
	public int? PrdValidityCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityDurationMin")]
	public int? PrdValidityDurationMin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdScore")]
	public double? PrdScore { get; set; }

	public bool? PrdValidityCounting { get; set; }

	public int? PrdValidityCountingNum { get; set; }

	public int? PrdValidityCountingMin { get; set; }

	public bool? PrdValidityCountingNumIsActive { get; set; }

	public bool? PrdValidityCountingNumNeedOrder { get; set; }

	public int? PrdValidityCountingNumDefaultVal { get; set; }

	public bool? PrdValidityCountingNumNoCheckRemain { get; set; }

	public bool? PrdValidityCountingMinIsActive { get; set; }

	public bool? PrdValidityCountingMinNeedOrder { get; set; }

	public int? PrdValidityCountingMinDefaultVal { get; set; }

	public bool? PrdValidityCountingMinNoCheckRemain { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdNickname")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdNickname { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdModuleName")]
	public string PrdModuleName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspPrdIndentify")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspPrdIndentify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspPrdName")]
	public string TspPrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcIndexed")]
	public bool? PrdAutoCalcIndexed { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordPrdId")]
	public int? PrdAutoCalcPordPrdId { get; set; }

	public string Search_PrdAutoCalcPordPrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPriceFromOrdItemRate")]
	public decimal? PrdAutoCalcPriceFromOrdItemRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcDisabled")]
	public bool? PrdAutoCalcDisabled { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPriceFromOrdItemPrdGroups")]
	public string PrdAutoCalcPriceFromOrdItemPrdGroups { get; set; }

	public string PrdAutoCalcPriceFromOrdItemPrdGroupsJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcDynamicRate")]
	public string PrdAutoCalcDynamicRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcInflationLastDurationRate")]
	public decimal? PrdAutoCalcInflationLastDurationRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcIndexedPrdId")]
	public int? PrdAutoCalcIndexedPrdId { get; set; }

	public string Search_PrdAutoCalcIndexedPrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordVerifyAfterIssue")]
	public bool? PrdAutoCalcPordVerifyAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordReferUser")]
	public int? PrdAutoCalcPordReferUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordExpireDynamicRate")]
	public bool? PrdAutoCalcPordExpireDynamicRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordExpireDay")]
	public int? PrdAutoCalcPordExpireDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoPordAddDateToItemDesc")]
	public string PrdAutoCalcPordItemDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordTaxDetectFromLastOrd")]
	public bool? PrdAutoCalcPordTaxDetectFromLastOrd { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordTaxDefSettingId")]
	public int? PrdAutoCalcPordTaxDefSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordNoTaxDefSettingId")]
	public int? PrdAutoCalcPordNoTaxDefSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordPrjTitleGroupId")]
	public int? PrdAutoCalcPordPrjTitleGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordPrjTitleId")]
	public int? PrdAutoCalcPordPrjTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordPrjPostFix")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdAutoCalcPordPrjPostFix { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordPrjCnvsStatusGroupId")]
	public int? PrdAutoCalcPordPrjCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordPrjFOCmpCanSee")]
	public bool? PrdAutoCalcPordPrjFOCmpCanSee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordPrjIsTicket")]
	public bool? PrdAutoCalcPordPrjIsTicket { get; set; }

	public int? PrdAutoCalcPordPrjUsedType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordAddCnvs")]
	public bool? PrdAutoCalcPordAddCnvs { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordCnvsTopicId")]
	public int? PrdAutoCalcPordCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordCnvsDesc")]
	public string PrdAutoCalcPordCnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordCnvsReferUser")]
	public int? PrdAutoCalcPordCnvsReferUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordCnvsStatusId")]
	public int? PrdAutoCalcPordCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordCnvsStatusResultId")]
	public int? PrdAutoCalcPordCnvsStatusResultId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPordCnvsRemindDay")]
	public int? PrdAutoCalcPordCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcIssueOrdFromIndexed")]
	public bool? PrdAutoCalcIssueOrdFromIndexed { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcIssueOrdFromIndexedOprId")]
	public int? PrdAutoCalcIssueOrdFromIndexedOprId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssueSetSetting")]
	public bool? PrdOrdIssueSetSetting { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssuePrjTitleGroupId")]
	public int? PrdOrdIssuePrjTitleGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssuePrjTitleId")]
	public int? PrdOrdIssuePrjTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssuePrjPostFix")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdOrdIssuePrjPostFix { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssuePrjCnvsStatusGroupId")]
	public int? PrdOrdIssuePrjCnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssuePrjRemindDay")]
	public int? PrdOrdIssuePrjRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssuePrjFOCmpCanSee")]
	public bool? PrdOrdIssuePrjFOCmpCanSee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssuePrjIsTicket")]
	public bool? PrdOrdIssuePrjIsTicket { get; set; }

	public int? PrdOrdIssuePrjUsedType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityUpdatePrjRemindDateAfterIssueOrd")]
	public bool? PrdValidityUpdatePrjRemindDateAfterIssueOrd { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssueUpdateCmpTypeId")]
	public int? PrdOrdIssueUpdateCmpTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssueUpdateCmpGroupII")]
	public bool? PrdOrdIssueUpdateCmpGroupII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssueUpdateTaxCmpGroupIdII")]
	public int? PrdOrdIssueUpdateTaxCmpGroupIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssueUpdateNoTaxCmpGroupIdII")]
	public int? PrdOrdIssueUpdateNoTaxCmpGroupIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrdIssueDateToCmpEffectiveDate")]
	public bool? PrdOrdIssueDateToCmpEffectiveDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcIndexBreakDay")]
	public int? PrdAutoCalcIndexBreakDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcDynamicRateJustCompleteDuration")]
	public bool? PrdAutoCalcDynamicRateJustCompleteDuration { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcInflationLastYearNumChange")]
	public bool? PrdAutoCalcInflationLastYearNumChange { get; set; }

	public bool? PrdAutoCalcInflationLastDuration { get; set; }

	public bool? PrdAutoCalcPriceFromOrdItemInBreak { get; set; }

	public bool? PrdAutoCalcPriceFromIndex { get; set; }

	public decimal? PrdAutoCalcInflationLastYearNumChangeRate { get; set; }

	public decimal? PrdAutoCalcPriceFromIndexRate { get; set; }

	public bool? PrdAutoCalcPriceFromOrdItem { get; set; }

	public bool? PrdAutoCalcPriceFromOrdItemAfterBreak { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityControlFOPrjTitleGroup")]
	public bool? PrdValidityControlFOPrjTitleGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityControlFOPrjTitleGroups")]
	public string PrdValidityControlFOPrjTitleGroupIds { get; set; }

	public string PrdValidityControlFOPrjTitleGroupIdsJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityControlFODeActivePrjTitleGroupDesc")]
	public string PrdValidityControlFODeActivePrjTitleGroupDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCanChangePrice")]
	public bool? PrdCanChangePrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleCenterIds")]
	public string PrdSaleCenterIds { get; set; }

	public string PrdSaleCenterNames { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDoneTimeMin")]
	public int? PrdDoneTimeMin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdLocation")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdLocation { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdRowColor")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdRowColor { get; set; }

	public string PrdName_Lang { get; set; }

	public string PrdType_Lang { get; set; }

	public string PrdDesign_Lang { get; set; }

	public string PrdSize_Lang { get; set; }

	public string PrdDescription_Lang { get; set; }

	public string PrdModel_Lang { get; set; }

	public string PrdManufacturerName_Lang { get; set; }

	public string PrdNickname_Lang { get; set; }

	public string PrdAutoCalcPordItemDesc_Lang { get; set; }

	public string PrdAutoCalcPordPrjPostFix_Lang { get; set; }

	public string PrdAutoCalcPordCnvsDesc_Lang { get; set; }

	public string PrdOrdIssuePrjPostFix_Lang { get; set; }

	public string PrdValidityControlFODeActivePrjTitleGroupDesc_Lang { get; set; }

	public string PrdLocation_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdWeight")]
	public double? PrdWeight { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPrice")]
	public bool? PrdAutoCalcPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoCalcPricePercent")]
	public decimal? PrdAutoCalcPricePercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdQtyCanDecimal")]
	public bool? PrdQtyCanDecimal { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdUnitIdII")]
	public int? PrdUnitIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdUnitIIRate")]
	public double? PrdUnitIIRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdUnitIIRateCalcAuto")]
	public bool? PrdUnitIIRateCalcAuto { get; set; }
}
