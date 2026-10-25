using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectBuyOrderPayments_Result
{
	public int ApiBuyOrderPaymentId { get; set; }

	public string ApiImportDate { get; set; }

	public int ApiBordpayTypeId { get; set; }

	public int ApiBordpayOrderId { get; set; }

	public int? ApiBordpayDocId { get; set; }

	public int? ApiBordpayDocTypeId { get; set; }

	public decimal ApiBordpayAmount { get; set; }

	public string ApiBordpayDocNumber { get; set; }

	public string ApiBordpayDocDate { get; set; }

	public string ApiBordpayDescription { get; set; }

	public int? BordpayFirstRegisterUserId { get; set; }

	public string ApiBordpayFirstRegisteDatePersian { get; set; }

	public DateTime? ApiBordpayFirstRegisteDate { get; set; }

	public int ApiUserId { get; set; }

	public int ApiFPId { get; set; }

	public short Month1 { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public DateTime? ApiImportDateTime { get; set; }

	public DateTime? ApiBordpayDocDateTime { get; set; }

	public string ApiAppType { get; set; }

	public decimal? ApiBordpayDocAmount { get; set; }

	public int? ApiLanguageID { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiBordpayType { get; set; }

	public int? ApiBordpayLinkAccHeaderId { get; set; }

	public string ApiBordpayLinkAccHeaderNumber { get; set; }

	public int? ApiBordpayLinkAccDetailId { get; set; }

	public int? ApiBordpayLinkAccVoucherId { get; set; }

	public string ApiBordpayLinkAccVoucherNumber { get; set; }

	public bool? ApiBordpayDeActive { get; set; }

	public decimal? ApiBordpayAmountTemp { get; set; }

	public string ApiBordpayDocDateTemp { get; set; }

	public DateTime? ApiBordpayDocDateTimeTemp { get; set; }
}
