using System;

namespace CRMIdealApi.ApiModels;

public class UpdateProductPriceViewModel : PublicParameters
{
	public int ApiPrdPriceId { get; set; }

	public string ApiPrdPriceDocDate { get; set; }

	public DateTime? ApiPrdPriceDocDateTime { get; set; }

	public string ApiPrdPriceDocNumber { get; set; }

	public decimal ApiPrdPrice { get; set; }

	public decimal? ApiPrdCurrencyPrice { get; set; }

	public int? ApiPrdPriceCurrencyUnitId { get; set; }

	public decimal? ApiPrdCooperationPrice { get; set; }

	public decimal? ApiPrdPricePercent { get; set; }

	public decimal? ApiPrdPriceDiscountPrecent { get; set; }

	public decimal? ApiPrdPriceDiscount { get; set; }

	public decimal? ApiPrdOtherPrice { get; set; }

	public string ApiPrdPriceDescription { get; set; }

	public int? ApiPrdPriceWHId { get; set; }

	public int? ApiPrdPriceGroupId { get; set; }

	public int? ApiProductId { get; set; }

	public string ApiLinkAccPrdPriceIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
