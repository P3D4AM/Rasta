using System;

namespace CRMIdealApi.ApiModels;

public class InsertBuyOrderPaymentViewModel : PublicParameters
{
	public int ApiBordpayTypeId { get; set; }

	public int ApiBordpayOrderId { get; set; }

	public decimal ApiBordpayAmount { get; set; }

	public string ApiBordpayDocNumber { get; set; }

	public string ApiBordpayDescription { get; set; }

	public string ApiBordpayDescription_Lang { get; set; }

	public DateTime? ApiImportDateTime { get; set; }

	public DateTime? ApiBordpayDocDateTime { get; set; }

	public decimal? ApiBordpayDocAmount { get; set; }

	public bool? ApiBordpayDeActive { get; set; }

	public string ApiBordpayAccountNumber { get; set; }

	public decimal? ApiBordpayAmountTemp { get; set; }

	public DateTime? ApiBordpayDocDateTimeTemp { get; set; }
}
