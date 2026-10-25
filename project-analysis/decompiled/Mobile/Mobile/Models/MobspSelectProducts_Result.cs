using System;

namespace Mobile.Models;

public class MobspSelectProducts_Result
{
	public int ProductID { get; set; }

	public int PrdGroupID { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public int? PrdColorId { get; set; }

	public int? PrdUnitId { get; set; }

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

	public DateTime RegisterDate { get; set; }

	public string PrdBarCode { get; set; }

	public int? PrdBarCodeTypeId { get; set; }

	public string PrdAutoNumBarcode { get; set; }

	public int? PrdAutoNumBarCodeTypeId { get; set; }

	public string PrdAutoCharBarcode { get; set; }

	public int? prdAutoCharBarCodeTypeId { get; set; }

	public string PrdModel { get; set; }

	public bool? PrdInactiveInSale { get; set; }

	public bool? PrdInactiveInBuy { get; set; }

	public bool? PrdCommissionDisable { get; set; }

	public double? PrdCommissionPercentRate { get; set; }

	public bool? PrdIsDefault { get; set; }

	public bool? PrdInActive { get; set; }

	public int? PrdKind { get; set; }

	public bool? PrdJustDefQuantity { get; set; }

	public double? PrdMinQuantity { get; set; }

	public double? PrdMaxQuantity { get; set; }

	public bool? PrdValidity { get; set; }

	public int? PrdValidityDay { get; set; }

	public string PrdValidityTime { get; set; }

	public int? PrdUnitIdI { get; set; }

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

	public string SGroupCode { get; set; }

	public string SGroupName { get; set; }

	public string SGroupNameEn { get; set; }

	public bool? SGroupInactiveInSale { get; set; }

	public bool? SGroupInactiveInBuy { get; set; }

	public int? FGroupId { get; set; }

	public string FGroupCode { get; set; }

	public string FGroupName { get; set; }

	public string FGroupNameEn { get; set; }

	public bool? FGroupInactiveInSale { get; set; }

	public bool? FGroupInactiveInBuy { get; set; }

	public string PrdColor { get; set; }

	public string PrdColorEn { get; set; }

	public string PrdUnit { get; set; }

	public string PrdUnitEn { get; set; }

	public int? PrdQuantityInUnit { get; set; }

	public double? PrdFCRInUnit { get; set; }

	public double? PrdFCRIInUnit { get; set; }

	public long? OrderView { get; set; }

	public string PrdUnitI { get; set; }

	public string PrdNickname { get; set; }

	public bool? PrdNoDiscount { get; set; }

	public decimal? PrdDiscountMax { get; set; }

	public bool? PrdCanChangePrice { get; set; }

	public int? PrdDoneTimeMin { get; set; }

	public string PrdSaleCenterIds { get; set; }

	public string PrdLocation { get; set; }

	public double? PrdWeight { get; set; }

	public string PrdDefQuantity { get; set; }

	public bool? PrdAutoCalcPrice { get; set; }

	public decimal? PrdAutoCalcPricePercent { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public string PrdLinkAccData { get; set; }

	public bool? PrdQtyCanDecimal { get; set; }

	public int? PrdUnitIdII { get; set; }

	public string PrdUnitII { get; set; }

	public double? PrdUnitIIRate { get; set; }

	public bool? PrdUnitIIRateCalcAuto { get; set; }
}
