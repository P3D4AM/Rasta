using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductPrice_Result
{
	public int ApiPrdPriceID { get; set; }

	public int ApiPrdId { get; set; }

	public string ApiProductName { get; set; }

	public string ApiDocDate { get; set; }

	public string ApiDocNumber { get; set; }

	public decimal ApiPrice { get; set; }

	public decimal? ApiCurrencyPrice { get; set; }

	public int? ApiCurrencyUnitId { get; set; }

	public string ApiCurrencyUnit { get; set; }

	public decimal? ApiCooperationPrice { get; set; }

	public decimal? ApiPricePercent { get; set; }

	public decimal? ApiDiscountPrecent { get; set; }

	public decimal? ApiDiscount { get; set; }

	public decimal? ApiOtherPrice { get; set; }

	public string ApiDescription { get; set; }

	public int ApiFPId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiWHId { get; set; }

	public string ApiWareHouse { get; set; }

	public int? ApiProductPriceGroupId { get; set; }

	public string ApiProductPriceGroup { get; set; }

	public DateTime? ApiDocDateTime { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiCId { get; set; }

	public string ApiLinkAccPrdPriceIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
