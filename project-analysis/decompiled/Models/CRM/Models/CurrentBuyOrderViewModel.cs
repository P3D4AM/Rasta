using System.Collections.Generic;

namespace CRM.Models;

public class CurrentBuyOrderViewModel
{
	public WSspSelectBuyOrders_Result BuyOrder { get; set; }

	public int BuyOrderCurrentId { get; set; }

	public int BuyOrderNextId { get; set; }

	public int BuyOrderPreviousId { get; set; }

	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public int CompanyId { get; set; }

	public long BuyOrderNumber { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int BuyOrderFirstId { get; set; }

	public int BuyOrderLastId { get; set; }

	public List<WSspSelectBuyOrderItems_Result> BuyOrderItemsList { get; set; }

	public List<WSspSelectBuyOrderPayments_Result> BuyOrderPayment { get; set; }

	public WSfnReturnBuyOrderSumFooter_Result FooterData { get; set; }

	public string DocInformation { get; set; }

	public int? DocId { get; set; }

	public int? OprType { get; set; }

	public decimal? SumBordPayAmount { get; set; }

	public decimal? RemainOrdAmount { get; set; }

	public decimal? RemainOlderordsAmount { get; set; }

	public List<WSspReturnDocForBuyOrder_Result> DocList { get; set; }

	public int WareHouseCount { get; set; }

	public bool IsDecimal { get; set; }

	public WSspReturnSumBuyOrderPay_Result FooterPay { get; set; }

	public string bordLinkAccBuyOrderIdStr { get; set; }

	public string bordLinkAccBuyOrderNumber { get; set; }

	public string bordLinkAccVoucherNumber { get; set; }

	public string bordLinkAccFirstTransferDateStr { get; set; }

	public string bordLinkAccLastTransferDateStr { get; set; }

	public WSspSelectVerificationWorkFlowStepLast_Result LastVerificationStep { get; set; }

	public List<WSspReturnOrderFromBuyOrder_Result> OrderList { get; set; }

	public string bordLinkAccData { get; set; }

	public bool IsSentToLinkAcc { get; set; }
}
