using System;

namespace CRM.Models;

public class WSspRpt_CmpOrdStockPayAccII_Result
{
	public long? RowNumber { get; set; }

	public int? rptUserId { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string rptUserName { get; set; }

	public int OrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int ordpayTypeId { get; set; }

	public string ordpayType { get; set; }

	public int ordpayOrderId { get; set; }

	public long? ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string OrderOpr { get; set; }

	public int? ordCompanyId { get; set; }

	public string Company { get; set; }

	public int? cmpNumber { get; set; }

	public decimal ordpayAmount { get; set; }

	public string ordpayDocNumber { get; set; }

	public string ordpayDocDate { get; set; }

	public string ordpayDescription { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? ordpayDocDateTime { get; set; }

	public decimal? ordpayDocAmount { get; set; }

	public string ordpayBankDocNumber { get; set; }

	public decimal? ordpayAmountTemp { get; set; }

	public decimal SumChqAmount { get; set; }

	public int? AllPage { get; set; }
}
