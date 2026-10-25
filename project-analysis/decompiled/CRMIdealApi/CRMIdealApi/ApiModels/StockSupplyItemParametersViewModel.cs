namespace CRMIdealApi.ApiModels;

public class StockSupplyItemParametersViewModel : PublicParameters
{
	public int ApiStockSupplyId { get; set; }

	public int ApiStsupIPrdId { get; set; }

	public float ApiStsupIQuantity { get; set; }

	public string ApiStsupIDescription { get; set; }

	public string ApiStsupIQuantityDesc { get; set; }

	public int? ApiStsupIPrdUnitId { get; set; }

	public int? ApiStsupIOrderView { get; set; }

	public float? ApiStsupIFCR { get; set; }

	public float? ApiStsupIFCRI { get; set; }

	public int? ApiStsupIWHId { get; set; }

	public string ApiStsupITracing { get; set; }

	public int? ApiStsupIPrdUnitIdI { get; set; }

	public float? ApiStsupIPrdUnitIRateResult { get; set; }

	public int? ApiStsupIPrdColorId { get; set; }

	public string ApiStsupIPrdNickname { get; set; }

	public int? ApiStsupIPreOrderId { get; set; }

	public int? ApiStsupIPreOrderItemId { get; set; }

	public string ApiStsupIBuyOrderIds { get; set; }

	public string ApiStsupIBuyOrderItemIds { get; set; }
}
