namespace CRM.Models;

public class RayvarzProductRemainingResponseViewModel
{
	public bool? isValidationsApplied { get; set; }

	public decimal? warehouseStock { get; set; }

	public decimal? warehouseStockDetail { get; set; }

	public decimal? warehouseStockPartialQtySum { get; set; }

	public decimal? reservedStock { get; set; }

	public decimal? reservedStockDetail { get; set; }

	public decimal? reservedStockPartialQtySum { get; set; }

	public decimal? remainedStock { get; set; }

	public decimal? remainedStockDetail { get; set; }

	public decimal? remainedStockPartialQtySum { get; set; }

	public decimal? inProcessStock { get; set; }

	public decimal? inProcessStockDetail { get; set; }

	public decimal? inProcessStockPartialQtySum { get; set; }

	public string itemDataId { get; set; }

	public string warehouseId { get; set; }

	public decimal? quantity { get; set; }

	public string salesBulkUnitName { get; set; }

	public RayvarzProductRemainingItemDataResponseViewModel itemData { get; set; }
}
