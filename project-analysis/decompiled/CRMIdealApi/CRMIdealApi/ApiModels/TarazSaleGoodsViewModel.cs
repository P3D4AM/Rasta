namespace CRMIdealApi.ApiModels;

public class TarazSaleGoodsViewModel
{
	public long? goodsID { get; set; }

	public long? priceListID { get; set; }

	public string goodsCode { get; set; }

	public string barCode { get; set; }

	public string goodsDesc { get; set; }

	public long? unitId { get; set; }

	public string unitDesc { get; set; }

	public decimal? price { get; set; }

	public decimal? lastListSaleFee { get; set; }

	public decimal? lastSaleFee { get; set; }

	public string techInfo { get; set; }

	public decimal? price1 { get; set; }

	public long? secUnitID { get; set; }

	public decimal? price2 { get; set; }

	public long? secUnitID2 { get; set; }

	public double? remain { get; set; }

	public decimal? secRemain { get; set; }

	public decimal? buyPrice { get; set; }

	public decimal? lastListBuyFee { get; set; }

	public decimal? lastBuyFee { get; set; }

	public decimal? buyPrice1 { get; set; }

	public long? buySecUnitID1 { get; set; }

	public long? differentialID { get; set; }

	public string differentialDesc { get; set; }

	public long? defaultSecUnitID { get; set; }

	public string secUnitName { get; set; }

	public string secUnitDesc { get; set; }

	public double? computeValue { get; set; }

	public long? serialType { get; set; }

	public string serialDesc { get; set; }

	public long? groupID { get; set; }

	public string groupDesc { get; set; }

	public string groupCode { get; set; }

	public string typeDesc { get; set; }

	public string latinDesc { get; set; }

	public string customTarrifNo { get; set; }

	public string goodsBriefName { get; set; }

	public bool? isbasket { get; set; }

	public string otherBarCode { get; set; }

	public decimal? baseFee { get; set; }

	public decimal? goodsDiscountPercent { get; set; }

	public decimal? goodsDiscountPrice { get; set; }

	public long? storeID { get; set; }

	public string storeCode { get; set; }

	public string storeName { get; set; }

	public string selType { get; set; }

	public string isQuantitativeDesc { get; set; }

	public bool? quantitative { get; set; }
}
