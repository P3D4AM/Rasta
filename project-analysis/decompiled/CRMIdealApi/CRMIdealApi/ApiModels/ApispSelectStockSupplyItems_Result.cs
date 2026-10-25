using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectStockSupplyItems_Result
{
	public int ApiStockSupplyItemId { get; set; }

	public int ApiStockSupplyId { get; set; }

	public int ApiStsupIPrdId { get; set; }

	public string ApiStsupIPrd { get; set; }

	public double ApiStsupIQuantity { get; set; }

	public string ApiStsupIDescription { get; set; }

	public string ApiStsupIQuantityDesc { get; set; }

	public int? ApiStsupIPrdUnitId { get; set; }

	public string ApiStsupIPrdUnit { get; set; }

	public int? ApiStsupIOrderView { get; set; }

	public double? ApiStsupIFCR { get; set; }

	public double? ApiStsupIFCRI { get; set; }

	public int? ApiStsupIWHId { get; set; }

	public string ApiStsupIWH { get; set; }

	public string ApiStsupITracing { get; set; }

	public int? ApiStsupIPrdUnitIdI { get; set; }

	public string ApiStsupIPrdUnitI { get; set; }

	public double? ApiStsupIPrdUnitIRateResult { get; set; }

	public int? ApiStsupIPrdColorId { get; set; }

	public string ApiStsupIPrdColor { get; set; }

	public string ApiStsupIPrdNickname { get; set; }

	public int? ApiStsupIPreOrderId { get; set; }

	public int? ApiStsupIPreOrderItemId { get; set; }

	public string ApiStsupIBuyOrderIds { get; set; }

	public string ApiStsupIBuyOrderItemIds { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }
}
