using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProducts_Result
{
	public int ApiProductID { get; set; }

	public int ApiPrdGroupID { get; set; }

	public string ApiPrdGroup { get; set; }

	public string ApiPrdCode { get; set; }

	public string ApiPrdName { get; set; }

	public string ApiPrdLatinName { get; set; }

	public string ApiPrdType { get; set; }

	public string ApiPrdDesign { get; set; }

	public string ApiPrdSize { get; set; }

	public int? ApiPrdColorId { get; set; }

	public string ApiPrdColor { get; set; }

	public int? ApiPrdUnitId { get; set; }

	public string ApiPrdUnit { get; set; }

	public int? ApiPrdMinQty { get; set; }

	public int? ApiPrdMaxQty { get; set; }

	public int? ApiPrdSleepDay { get; set; }

	public string ApiPrdFirstSerial { get; set; }

	public string ApiPrdSecondSerial { get; set; }

	public string ApiPrdThirdSerial { get; set; }

	public string ApiPrdFirstBarcode { get; set; }

	public string ApiPrdSecondBarcode { get; set; }

	public string ApiPrdThirdBarcode { get; set; }

	public string ApiPrdDescription { get; set; }

	public int ApiFPId { get; set; }

	public string ApiPrdBarCode { get; set; }

	public int? ApiPrdBarCodeTypeId { get; set; }

	public string ApiPrdAutoNumBarcode { get; set; }

	public int? ApiPrdAutoNumBarCodeTypeId { get; set; }

	public string ApiPrdAutoCharBarcode { get; set; }

	public int? ApiprdAutoCharBarCodeTypeId { get; set; }

	public string ApiPrdModel { get; set; }

	public bool? ApiPrdInactiveInSale { get; set; }

	public bool? ApiPrdInactiveInBuy { get; set; }

	public bool? ApiPrdCommissionDisable { get; set; }

	public double? ApiPrdCommissionPercentRate { get; set; }

	public bool? ApiPrdSHPIsActive { get; set; }

	public string ApiPrdSHPTitle { get; set; }

	public string ApiPrdSHPCode { get; set; }

	public string ApiPrdSHPModel { get; set; }

	public string ApiPrdSHPDescription { get; set; }

	public string ApiPrdSHPDescriptionII { get; set; }

	public int? ApiPrdSHPStockManageTypeId { get; set; }

	public double? ApiPrdSHPStockManualyCount { get; set; }

	public bool? ApiPrdSHPHiddenPriceInNoStock { get; set; }

	public bool? ApiPrdSHPSelfSupplier { get; set; }

	public int? ApiPrdSHPOtherSupplierId { get; set; }

	public string ApiPrdSHPOtherSupplier { get; set; }

	public int? ApiOrderView { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiPrdFGroupId { get; set; }

	public string ApiPrdFGroupName { get; set; }

	public string ApiPrdLinkAccPrdCode { get; set; }

	public bool? ApiPrdValidity { get; set; }

	public int? ApiPrdValidityDay { get; set; }

	public string ApiPrdValidityTime { get; set; }

	public bool? ApiPrdValidityCounting { get; set; }

	public int? ApiPrdValidityCountingNum { get; set; }

	public int? ApiPrdValidityCountingMin { get; set; }

	public bool? ApiPrdValidityCountingNumIsActive { get; set; }

	public bool? ApiPrdValidityCountingNumNeedOrder { get; set; }

	public int? ApiPrdValidityCountingNumDefaultVal { get; set; }

	public bool? PrdValidityCountingNumNoCheckRemain { get; set; }

	public bool? ApiPrdValidityCountingMinIsActive { get; set; }

	public bool? ApiPrdValidityCountingMinNeedOrder { get; set; }

	public int? ApiPrdValidityCountingMinDefaultVal { get; set; }

	public bool? ApiPrdValidityCountingMinNoCheckRemain { get; set; }

	public bool? ApiPrdValidityUpdatePrjRemindDateAfterIssueOrd { get; set; }

	public bool? ApiPrdValidityControlFOPrjTitleGroup { get; set; }

	public string ApiPrdValidityControlFOPrjTitleGroupIds { get; set; }

	public string ApiPrdValidityControlFODeActivePrjTitleGroupDesc { get; set; }

	public int? ApiPrdDoneTimeMin { get; set; }

	public string ApiPrdLocation { get; set; }

	public string ApiPrdRowColor { get; set; }

	public double? ApiPrdWeight { get; set; }

	public bool? ApiPrdSHPQtyFromTracing { get; set; }

	public bool? ApiPrdSHPShowLinkedPrd { get; set; }

	public int? ApiPrdLinkAccPrdId { get; set; }

	public string ApiPrdLinkAccPrdIdStr { get; set; }

	public string ApiPrdLinkAccPrdGroupIdStr { get; set; }

	public DateTime? ApiPrdLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiPrdLinkAccLastTransferDate { get; set; }

	public string ApiPrdLinkAccData { get; set; }

	public bool? ApiPrdIsDefault { get; set; }

	public bool? ApiPrdInActive { get; set; }

	public int? ApiPrdKind { get; set; }

	public bool? ApiPrdJustDefQuantity { get; set; }

	public double? ApiPrdMinQuantity { get; set; }

	public double? ApiPrdMaxQuantity { get; set; }

	public string ApiPrdManufacturerName { get; set; }

	public string ApiPrdManufacturerCode { get; set; }

	public bool? ApiPrdIVRLink { get; set; }

	public string ApiPrdIVRLinkRule { get; set; }

	public string ApiPrdIVRLinkDesc { get; set; }

	public int? ApiPrdUnitIdI { get; set; }

	public double? ApiPrdUnitIRate { get; set; }

	public bool? ApiPrdUnitIRateCalcAuto { get; set; }

	public bool? ApiPrdQtyNoFCR { get; set; }

	public bool? ApiPrdMustFullTracingCode { get; set; }

	public bool? ApiPrdSingleItem { get; set; }

	public double? ApiPrdScore { get; set; }

	public string ApiPrdNickname { get; set; }

	public bool? ApiPrdNoDiscount { get; set; }

	public decimal? ApiPrdDiscountMax { get; set; }

	public bool? ApiPrdTaxable { get; set; }

	public decimal? ApiPrdTaxableIndex { get; set; }

	public bool? ApiPrdCashBack { get; set; }

	public decimal? ApiPrdCashBackIndex { get; set; }

	public string ApiPrdModuleName { get; set; }

	public string ApiTspPrdIndentify { get; set; }

	public string ApiTspPrdName { get; set; }

	public bool? ApiPrdAutoCalcIndexed { get; set; }

	public int? ApiPrdAutoCalcPordPrdId { get; set; }

	public string ApiPrdAutoCalcPordPrd { get; set; }

	public decimal? ApiPrdAutoCalcPriceFromOrdItemRate { get; set; }

	public bool? ApiPrdAutoCalcDisabled { get; set; }

	public string ApiPrdAutoCalcPriceFromOrdItemPrdGroups { get; set; }

	public string ApiPrdAutoCalcDynamicRate { get; set; }

	public decimal? ApiPrdAutoCalcInflationLastDurationRate { get; set; }

	public int? ApiPrdAutoCalcIndexedPrdId { get; set; }

	public string ApiPrdAutoCalcIndexedPrd { get; set; }

	public bool? ApiPrdAutoCalcPordVerifyAfterIssue { get; set; }

	public int? ApiPrdAutoCalcPordReferUser { get; set; }

	public bool? ApiPrdAutoCalcPordExpireDynamicRate { get; set; }

	public int? ApiPrdAutoCalcPordExpireDay { get; set; }

	public string ApiPrdAutoCalcPordItemDesc { get; set; }

	public bool? ApiPrdAutoCalcPordTaxDetectFromLastOrd { get; set; }

	public int? ApiPrdAutoCalcPordTaxDefSettingId { get; set; }

	public string ApiPrdAutoCalcPordTaxDefSetting { get; set; }

	public int? ApiPrdAutoCalcPordNoTaxDefSettingId { get; set; }

	public string ApiPrdAutoCalcPordNoTaxDefSetting { get; set; }

	public int? ApiPrdAutoCalcPordPrjTitleGroupId { get; set; }

	public string ApiPrdAutoCalcPordPrjTitleGroup { get; set; }

	public int? ApiPrdAutoCalcPordPrjTitleId { get; set; }

	public string ApiPrdAutoCalcPordPrjTitle { get; set; }

	public string ApiPrdAutoCalcPordPrjPostFix { get; set; }

	public int? ApiPrdAutoCalcPordPrjCnvsStatusGroupId { get; set; }

	public string ApiPrdAutoCalcPordPrjCnvsStatusGroup { get; set; }

	public bool? ApiPrdAutoCalcPordPrjFOCmpCanSee { get; set; }

	public bool? ApiPrdAutoCalcPordPrjIsTicket { get; set; }

	public int? ApiPrdAutoCalcPordPrjUsedType { get; set; }

	public bool? ApiPrdAutoCalcPordAddCnvs { get; set; }

	public int? ApiPrdAutoCalcPordCnvsTopicId { get; set; }

	public string ApiPrdAutoCalcPordCnvsTopic { get; set; }

	public string ApiPrdAutoCalcPordCnvsDesc { get; set; }

	public int? ApiPrdAutoCalcPordCnvsReferUser { get; set; }

	public int? ApiPrdAutoCalcPordCnvsStatusId { get; set; }

	public string ApiPrdAutoCalcPordCnvsStatus { get; set; }

	public int? ApiPrdAutoCalcPordCnvsStatusResultId { get; set; }

	public string ApiPrdAutoCalcPordCnvsStatusResult { get; set; }

	public int? ApiPrdAutoCalcPordCnvsRemindDay { get; set; }

	public bool? ApiPrdAutoCalcIssueOrdFromIndexed { get; set; }

	public int? ApiPrdAutoCalcIssueOrdFromIndexedOprId { get; set; }

	public string ApiPrdAutoCalcIssueOrdFromIndexedOpr { get; set; }

	public bool? ApiPrdOrdIssueSetSetting { get; set; }

	public int? ApiPrdOrdIssuePrjTitleGroupId { get; set; }

	public string ApiPrdOrdIssuePrjTitleGroup { get; set; }

	public int? ApiPrdOrdIssuePrjTitleId { get; set; }

	public string ApiPrdOrdIssuePrjTitle { get; set; }

	public string ApiPrdOrdIssuePrjPostFix { get; set; }

	public int? ApiPrdOrdIssuePrjCnvsStatusGroupId { get; set; }

	public string ApiPrdOrdIssuePrjCnvsStatusGroup { get; set; }

	public int? ApiPrdOrdIssuePrjRemindDay { get; set; }

	public bool? ApiPrdOrdIssuePrjFOCmpCanSee { get; set; }

	public bool? ApiPrdOrdIssuePrjIsTicket { get; set; }

	public int? ApiPrdOrdIssuePrjUsedType { get; set; }

	public int? ApiPrdOrdIssueUpdateCmpTypeId { get; set; }

	public string ApiPrdOrdIssueUpdateCmpType { get; set; }

	public bool? ApiPrdOrdIssueUpdateCmpGroupII { get; set; }

	public int? ApiPrdOrdIssueUpdateTaxCmpGroupIdII { get; set; }

	public int? ApiPrdOrdIssueUpdateNoTaxCmpGroupIdII { get; set; }

	public bool? ApiPrdOrdIssueDateToCmpEffectiveDate { get; set; }

	public int? ApiPrdAutoCalcIndexBreakDay { get; set; }

	public bool? ApiPrdAutoCalcDynamicRateJustCompleteDuration { get; set; }

	public bool? ApiPrdAutoCalcInflationLastYearNumChange { get; set; }

	public bool? ApiPrdAutoCalcPriceFromOrdItemInBreak { get; set; }

	public bool? ApiPrdAutoCalcPriceFromIndex { get; set; }

	public bool? ApiPrdAutoCalcInflationLastDuration { get; set; }

	public decimal? ApiPrdAutoCalcInflationLastYearNumChangeRate { get; set; }

	public decimal? ApiPrdAutoCalcPriceFromIndexRate { get; set; }

	public bool? ApiPrdAutoCalcPriceFromOrdItem { get; set; }

	public bool? ApiPrdAutoCalcPriceFromOrdItemAfterBreak { get; set; }

	public bool? ApiPrdCanChangePrice { get; set; }

	public string ApiPrdSaleCenterIds { get; set; }

	public string ApiPrdDefQuantity { get; set; }

	public long? ApiRowNumber { get; set; }

	public int? ApiTotalCount { get; set; }

	public int? ApiPrdUnitIdII { get; set; }

	public double? ApiPrdUnitIIRate { get; set; }

	public bool? ApiPrdUnitIIRateCalcAuto { get; set; }
}
