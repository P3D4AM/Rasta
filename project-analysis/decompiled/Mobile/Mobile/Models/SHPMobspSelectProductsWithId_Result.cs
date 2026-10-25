using System;

namespace Mobile.Models;

public class SHPMobspSelectProductsWithId_Result
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

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePerWithSlash { get; set; }

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

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePerWithSlash { get; set; }

	public bool? PrdSHPIsActive { get; set; }

	public string PrdSHPTitle { get; set; }

	public string PrdSHPCode { get; set; }

	public string PrdSHPDescription { get; set; }

	public string PrdSHPDescriptionII { get; set; }

	public string PrdSHPModel { get; set; }

	public int? PrdSHPStockManageTypeId { get; set; }

	public double? PrdSHPStockManualyCount { get; set; }

	public bool? PrdSHPSelfSupplier { get; set; }

	public int? PrdSHPOtherSupplierId { get; set; }

	public bool? PrdSHPHiddenPriceInNoStock { get; set; }

	public string PrdSHPSupplier { get; set; }

	public double? PrdSHPRealStock { get; set; }

	public double? PrdSHPLinkAccStock { get; set; }

	public string PrdSGroupName { get; set; }

	public int? PrdFGroupId { get; set; }

	public string PrdFGroupName { get; set; }

	public string PrdColor { get; set; }

	public string PrdColorEn { get; set; }

	public string PrdUnit { get; set; }

	public string PrdUnitEn { get; set; }

	public double? PrdUnitFCR { get; set; }

	public double? PrdUnitFCRI { get; set; }

	public string PrdSHPUnit { get; set; }

	public decimal? PrdPrice { get; set; }

	public int? CurrencyUnitId { get; set; }

	public string CurrencyUnit { get; set; }

	public string CurrencyUnitEn { get; set; }

	public decimal? PrdDiscountPrecent { get; set; }

	public decimal? PrdDiscount { get; set; }

	public decimal? PrdPriceAfterDiscount { get; set; }

	public decimal? PrePaymentPrice { get; set; }

	public int? SumRate { get; set; }

	public int? CountRate { get; set; }

	public decimal? TotalRate { get; set; }

	public string PrdDeliveryScheduleToDay { get; set; }

	public int? PrdDeliveryScheduleCountInWeek { get; set; }

	public int? PrdLinkAccPrdId { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public string PrdLinkAccPrdIdStr { get; set; }

	public string PrdLinkAccPrdGroupIdStr { get; set; }

	public int? FGLinkAccGroupId { get; set; }

	public string FGLinkAccGroupCode { get; set; }

	public string FGLinkAccGroupIdStr { get; set; }

	public int? SGLinkAccGroupId { get; set; }

	public string SGLinkAccGroupCode { get; set; }

	public string SGLinkAccGroupIdStr { get; set; }

	public int? PrdKind { get; set; }

	public string PrdSaleCenterIds { get; set; }

	public string PrdSaleCenterJs { get; set; }

	public int? PrdDoneTimeMin { get; set; }

	public string PrdSaleCentersParentIds { get; set; }

	public bool? PrdJustDefQuantity { get; set; }

	public string SGSHPName { get; set; }

	public string FGSHPName { get; set; }
}
