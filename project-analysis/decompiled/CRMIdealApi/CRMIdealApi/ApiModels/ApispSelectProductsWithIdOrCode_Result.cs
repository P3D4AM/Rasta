using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductsWithIdOrCode_Result
{
	public int ProductID { get; set; }

	public int PrdGroupID { get; set; }

	public string PrdSGroupName { get; set; }

	public int? PrdFGroupId { get; set; }

	public string PrdFGroupName { get; set; }

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
}
