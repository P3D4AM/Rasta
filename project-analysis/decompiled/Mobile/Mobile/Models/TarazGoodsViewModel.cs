using System;

namespace Mobile.Models;

public class TarazGoodsViewModel
{
	public long? goodsID { get; set; }

	public string goodsCode { get; set; }

	public string goodsDesc { get; set; }

	public string secGoodsCode { get; set; }

	public string techInfo { get; set; }

	public bool? goodIdentity { get; set; }

	public DateTime? createDate { get; set; }

	public long? creatorID { get; set; }

	public DateTime? modifyDate { get; set; }

	public long? modifierID { get; set; }

	public long? serverID { get; set; }

	public string latinDesc { get; set; }

	public long? minQuantity { get; set; }

	public long? maxQuantity { get; set; }

	public long? orderPoint { get; set; }

	public long? orderCount { get; set; }

	public long? pricingMethod { get; set; }

	public bool? isNotActive { get; set; }

	public string goodsBriefName { get; set; }

	public string customTarrifNo { get; set; }

	public bool? isBasket { get; set; }

	public string barCode { get; set; }

	public long? baseFee { get; set; }

	public long? orderPick { get; set; }

	public decimal? goodsDiscountPercent { get; set; }

	public string fullGoodsCode { get; set; }

	public decimal? goodsDiscountPrice { get; set; }

	public long? unitID { get; set; }

	public string unitCode { get; set; }

	public string unitDesc { get; set; }

	public long? groupID { get; set; }

	public string groupCode { get; set; }

	public string groupDesc { get; set; }

	public long? typeID { get; set; }

	public string typeCode { get; set; }

	public string typeDesc { get; set; }

	public long? tafsiliID { get; set; }

	public string tafsiliCode { get; set; }

	public long? tafsiliTypeID { get; set; }

	public string tafsiliTypeDesc { get; set; }

	public string goodIdentityDesc { get; set; }

	public double? countGoods { get; set; }

	public string goodspositionCode { get; set; }

	public string goodsPositionDesc { get; set; }

	public bool? hasInvFlow { get; set; }

	public bool? hasBuyFlow { get; set; }

	public bool? hasSaleFlow { get; set; }

	public double? coEffValue { get; set; }

	public string pricingDesc { get; set; }

	public string secUnitName { get; set; }

	public long? goodsPositionID { get; set; }

	public bool? hasAnalysis { get; set; }

	public string creatorName { get; set; }

	public string modifierName { get; set; }

	public bool? isFixFee { get; set; }

	public bool? isProductable { get; set; }

	public bool? isBuyable { get; set; }

	public double? minFee { get; set; }

	public double? maxFee { get; set; }
}
