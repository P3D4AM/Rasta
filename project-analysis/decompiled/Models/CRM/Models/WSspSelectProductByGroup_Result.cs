using System;

namespace CRM.Models;

public class WSspSelectProductByGroup_Result
{
	public int ProductID { get; set; }

	public int PrdGroupID { get; set; }

	public string PrdSGName { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public int? PrdColorId { get; set; }

	public string PrdColor { get; set; }

	public int? PrdUnitId { get; set; }

	public string PrdUnit { get; set; }

	public int? PrdMinQty { get; set; }

	public int? PrdMaxQty { get; set; }

	public int? PrdSleepDay { get; set; }

	public string PrdFirstSerial { get; set; }

	public string PrdSecondSerial { get; set; }

	public string PrdThirdSerial { get; set; }

	public string PrdFirstBarcode { get; set; }

	public string PrdSecondBarcode { get; set; }

	public string PrdThirdBarcode { get; set; }

	public string PrdDescription { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string PrdBarCode { get; set; }

	public int? PrdBarCodeTypeId { get; set; }

	public string PrdAutoNumBarcode { get; set; }

	public int? PrdAutoNumBarCodeTypeId { get; set; }

	public string PrdAutoCharBarcode { get; set; }

	public int? prdAutoCharBarCodeTypeId { get; set; }

	public string PrdModel { get; set; }

	public Guid? GUId { get; set; }

	public bool? PrdInactiveInSale { get; set; }

	public bool? PrdInactiveInBuy { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? PrdSHPIsActive { get; set; }

	public string PrdSHPTitle { get; set; }

	public string PrdSHPCode { get; set; }

	public string PrdSHPModel { get; set; }

	public string PrdSHPDescription { get; set; }

	public string PrdSHPDescriptionII { get; set; }

	public int? PrdSHPStockManageTypeId { get; set; }

	public double? PrdSHPStockManualyCount { get; set; }

	public bool? PrdSHPHiddenPriceInNoStock { get; set; }

	public bool? PrdSHPSelfSupplier { get; set; }

	public int? PrdSHPOtherSupplierId { get; set; }

	public int? PrdLinkAccPrdId { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public int? OrderView { get; set; }

	public bool? PrdCommissionDisable { get; set; }

	public double? PrdCommissionPercentRate { get; set; }

	public string PrdLinkAccPrdIdStr { get; set; }

	public bool? PrdIsDefault { get; set; }

	public bool? PrdInActive { get; set; }

	public int? PrdKind { get; set; }

	public bool? PrdJustDefQuantity { get; set; }

	public double? PrdMinQuantity { get; set; }

	public double? PrdMaxQuantity { get; set; }

	public string PrdManufacturerName { get; set; }

	public string PrdManufacturerCode { get; set; }

	public string PrdLinkAccPrdGroupIdStr { get; set; }

	public bool? PrdIVRLink { get; set; }

	public string PrdIVRLinkRule { get; set; }

	public string PrdIVRLinkDesc { get; set; }

	public bool? PrdValidity { get; set; }

	public int? PrdValidityDay { get; set; }

	public string PrdValidityTime { get; set; }

	public int? PrdUnitIdI { get; set; }

	public string PrdUnitI { get; set; }

	public double? PrdUnitIRate { get; set; }

	public bool? PrdUnitIRateCalcAuto { get; set; }

	public bool? PrdQtyNoFCR { get; set; }

	public bool? PrdMustFullTracingCode { get; set; }

	public bool? PrdSingleItem { get; set; }

	public bool? PrdValidityCounting { get; set; }

	public int? PrdValidityCountingNum { get; set; }

	public int? PrdValidityCountingMin { get; set; }

	public double? PrdScore { get; set; }

	public bool? PrdValidityCountingNumIsActive { get; set; }

	public bool? PrdValidityCountingNumNeedOrder { get; set; }

	public int? PrdValidityCountingNumDefaultVal { get; set; }

	public bool? PrdValidityCountingNumNoCheckRemain { get; set; }

	public bool? PrdValidityCountingMinIsActive { get; set; }

	public bool? PrdValidityCountingMinNeedOrder { get; set; }

	public int? PrdValidityCountingMinDefaultVal { get; set; }

	public bool? PrdValidityCountingMinNoCheckRemain { get; set; }

	public string PrdNickname { get; set; }

	public bool? PrdNoDiscount { get; set; }

	public decimal? PrdDiscountMax { get; set; }

	public bool? PrdTaxable { get; set; }

	public decimal? PrdTaxableIndex { get; set; }

	public bool? PrdCashBack { get; set; }

	public decimal? PrdCashBackIndex { get; set; }

	public string PrdModuleName { get; set; }

	public string TspPrdIndentify { get; set; }

	public string TspPrdName { get; set; }

	public bool? PrdAutoCalcIndexed { get; set; }

	public int? PrdAutoCalcPordPrdId { get; set; }

	public decimal? PrdAutoCalcPriceFromOrdItemRate { get; set; }

	public bool? PrdAutoCalcDisabled { get; set; }

	public string PrdAutoCalcPriceFromOrdItemPrdGroups { get; set; }

	public string PrdAutoCalcDynamicRate { get; set; }

	public decimal? PrdAutoCalcInflationLastDurationRate { get; set; }

	public int? PrdAutoCalcIndexedPrdId { get; set; }

	public bool? PrdAutoCalcPordVerifyAfterIssue { get; set; }

	public int? PrdAutoCalcPordReferUser { get; set; }

	public bool? PrdAutoCalcPordExpireDynamicRate { get; set; }

	public int? PrdAutoCalcPordExpireDay { get; set; }

	public string PrdAutoCalcPordItemDesc { get; set; }

	public bool? PrdAutoCalcPordTaxDetectFromLastOrd { get; set; }

	public int? PrdAutoCalcPordTaxDefSettingId { get; set; }

	public int? PrdAutoCalcPordNoTaxDefSettingId { get; set; }

	public int? PrdAutoCalcPordPrjTitleGroupId { get; set; }

	public int? PrdAutoCalcPordPrjTitleId { get; set; }

	public string PrdAutoCalcPordPrjPostFix { get; set; }

	public int? PrdAutoCalcPordPrjCnvsStatusGroupId { get; set; }

	public bool? PrdAutoCalcPordPrjFOCmpCanSee { get; set; }

	public bool? PrdAutoCalcPordPrjIsTicket { get; set; }

	public int? PrdAutoCalcPordPrjUsedType { get; set; }

	public bool? PrdAutoCalcPordAddCnvs { get; set; }

	public int? PrdAutoCalcPordCnvsTopicId { get; set; }

	public string PrdAutoCalcPordCnvsDesc { get; set; }

	public int? PrdAutoCalcPordCnvsReferUser { get; set; }

	public int? PrdAutoCalcPordCnvsStatusId { get; set; }

	public int? PrdAutoCalcPordCnvsStatusResultId { get; set; }

	public int? PrdAutoCalcPordCnvsRemindDay { get; set; }

	public bool? PrdAutoCalcIssueOrdFromIndexed { get; set; }

	public int? PrdAutoCalcIssueOrdFromIndexedOprId { get; set; }

	public bool? PrdOrdIssueSetSetting { get; set; }

	public int? PrdOrdIssuePrjTitleGroupId { get; set; }

	public int? PrdOrdIssuePrjTitleId { get; set; }

	public string PrdOrdIssuePrjPostFix { get; set; }

	public int? PrdOrdIssuePrjCnvsStatusGroupId { get; set; }

	public int? PrdOrdIssuePrjRemindDay { get; set; }

	public bool? PrdOrdIssuePrjFOCmpCanSee { get; set; }

	public bool? PrdOrdIssuePrjIsTicket { get; set; }

	public int? PrdOrdIssuePrjUsedType { get; set; }

	public bool? PrdValidityUpdatePrjRemindDateAfterIssueOrd { get; set; }

	public int? PrdOrdIssueUpdateCmpTypeId { get; set; }

	public bool? PrdOrdIssueUpdateCmpGroupII { get; set; }

	public int? PrdOrdIssueUpdateTaxCmpGroupIdII { get; set; }

	public int? PrdOrdIssueUpdateNoTaxCmpGroupIdII { get; set; }

	public bool? PrdOrdIssueDateToCmpEffectiveDate { get; set; }

	public int? PrdAutoCalcIndexBreakDay { get; set; }

	public bool? PrdAutoCalcDynamicRateJustCompleteDuration { get; set; }

	public bool? PrdAutoCalcInflationLastYearNumChange { get; set; }

	public bool? PrdAutoCalcPriceFromOrdItemInBreak { get; set; }

	public bool? PrdAutoCalcPriceFromIndex { get; set; }

	public bool? PrdAutoCalcInflationLastDuration { get; set; }

	public decimal? PrdAutoCalcInflationLastYearNumChangeRate { get; set; }

	public decimal? PrdAutoCalcPriceFromIndexRate { get; set; }

	public bool? PrdAutoCalcPriceFromOrdItem { get; set; }

	public bool? PrdAutoCalcPriceFromOrdItemAfterBreak { get; set; }

	public bool? PrdValidityControlFOPrjTitleGroup { get; set; }

	public string PrdValidityControlFOPrjTitleGroupIds { get; set; }

	public string PrdValidityControlFODeActivePrjTitleGroupDesc { get; set; }

	public string PrdColorCode { get; set; }

	public string PrdAutoCalcPordCnvsTopic { get; set; }

	public string PrdOrdIssueUpdateCmpType { get; set; }

	public string PrdOrdIssueUpdateTaxCmpGroupII { get; set; }

	public string PrdOrdIssueUpdateNoTaxCmpGroupII { get; set; }

	public string PrdOrdIssuePrjCnvsStatusGroup { get; set; }

	public string PrdOrdIssuePrjTitle { get; set; }

	public string PrdOrdIssuePrjTitleGroup { get; set; }

	public string PrdAutoCalcIssueOrdFromIndexedOpr { get; set; }

	public string PrdAutoCalcPordCnvsStatusResult { get; set; }

	public string PrdAutoCalcPordCnvsStatus { get; set; }

	public string PrdAutoCalcPordPrjCnvsStatusGroup { get; set; }

	public string PrdAutoCalcPordPrjTitle { get; set; }

	public string PrdAutoCalcPordPrjTitleGroup { get; set; }

	public string PrdAutoCalcPordNoTaxDefSetting { get; set; }

	public string PrdAutoCalcPordTaxDefSetting { get; set; }

	public string PrdAutoCalcIndexedPrd { get; set; }

	public string PrdAutoCalcPordPrd { get; set; }

	public string PrdAutoCalcPordReferUsername { get; set; }

	public string PrdAutoCalcPordCnvsReferUsername { get; set; }

	public string PrdAutoCalcPriceFromOrdItemPrdGroupsJs { get; set; }

	public string PrdValidityControlFOPrjTitleGroupsJs { get; set; }

	public string PriceListJs { get; set; }

	public bool? PrdCanChangePrice { get; set; }

	public DateTime? PrdLinkAccFirstTransferDate { get; set; }

	public DateTime? PrdLinkAccLastTransferDate { get; set; }

	public string PrdLinkAccFirstTransferDateStr { get; set; }

	public string PrdLinkAccLastTransferDateStr { get; set; }

	public string PrdLinkAccData { get; set; }

	public string PrdSaleCenterIds { get; set; }

	public string PrdSaleCenterNames { get; set; }

	public int? PrdDoneTimeMin { get; set; }

	public string PrdLocation { get; set; }

	public string PrdRowColor { get; set; }

	public double? PrdWeight { get; set; }

	public bool? PrdAutoCalcPrice { get; set; }

	public decimal? PrdAutoCalcPricePercent { get; set; }

	public string PrdDefQuantity { get; set; }

	public bool? PrdQtyCanDecimal { get; set; }

	public int? PrdUnitIdII { get; set; }

	public string PrdUnitII { get; set; }

	public double? PrdUnitIIRate { get; set; }

	public bool? PrdUnitIIRateCalcAuto { get; set; }
}
