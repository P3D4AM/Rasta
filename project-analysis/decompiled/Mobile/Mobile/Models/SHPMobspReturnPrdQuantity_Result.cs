namespace Mobile.Models;

public class SHPMobspReturnPrdQuantity_Result
{
	public int ProductID { get; set; }

	public int PrdGroupID { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdSHPTitle { get; set; }

	public string PrdSHPCode { get; set; }

	public int? PrdSHPStockManageTypeId { get; set; }

	public double? PrdSHPStockManualyCount { get; set; }

	public bool? PrdSHPSelfSupplier { get; set; }

	public int? PrdSHPOtherSupplierId { get; set; }

	public bool? PrdSHPHiddenPriceInNoStock { get; set; }

	public bool? PrdSHPQtyFromTracing { get; set; }

	public double? PrdSHPRealStock { get; set; }

	public double? PrdSHPLinkAccStock { get; set; }
}
