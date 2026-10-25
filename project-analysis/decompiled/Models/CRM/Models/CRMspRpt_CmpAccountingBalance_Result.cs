namespace CRM.Models;

public class CRMspRpt_CmpAccountingBalance_Result
{
	public string rptUserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public int CompanyID { get; set; }

	public string CompanyName { get; set; }

	public int? cmpNumber { get; set; }

	public decimal? SumPreOrderTotalAmount { get; set; }

	public decimal? SumSaleOrderTotalAmount { get; set; }

	public decimal? SumReturnOrderTotalAmount { get; set; }

	public decimal? SumBuyOrderTotalAmount { get; set; }

	public decimal? SumBuyOrderInDocTotalAmount { get; set; }

	public decimal SumCmpPay { get; set; }

	public decimal SumRetToCmpPay { get; set; }

	public decimal? TotalRemain { get; set; }
}
