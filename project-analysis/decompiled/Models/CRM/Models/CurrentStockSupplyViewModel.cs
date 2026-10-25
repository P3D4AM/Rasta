using System.Collections.Generic;

namespace CRM.Models;

public class CurrentStockSupplyViewModel
{
	public WSspSelectStockSupply_Result StockSupply { get; set; }

	public List<WSspSelectStockSupplyItems_Result> StockSupplyItemsList { get; set; }

	public WSspReturnStockSupplySumFooter_Result FooterData { get; set; }

	public WSspSelectVerificationWorkFlowStepLast_Result LastVerificationStep { get; set; }

	public int StockSupplyCurrentId { get; set; }

	public int StockSupplyNextId { get; set; }

	public int StockSupplyPreviousId { get; set; }

	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public int CompanyId { get; set; }

	public long StockSupplyNumber { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int StockSupplyFirstId { get; set; }

	public int StockSupplyLastId { get; set; }

	public string PreOrderInfo { get; set; }

	public int? PreOrderId { get; set; }

	public int WareHouseCount { get; set; }
}
