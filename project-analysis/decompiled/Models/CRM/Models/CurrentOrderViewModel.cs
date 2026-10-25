using System.Collections.Generic;

namespace CRM.Models;

public class CurrentOrderViewModel
{
	public WSspSelectOrdersInMode_Result Order { get; set; }

	public int OrderCurrentId { get; set; }

	public int OrderNextId { get; set; }

	public int OrderPreviousId { get; set; }

	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public int CompanyId { get; set; }

	public long OrderNumber { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int OrderFirstId { get; set; }

	public int OrderLastId { get; set; }

	public List<WSspSelectOrderItems_Result> OrderItemsList { get; set; }

	public List<WSspSelectOrderPayments_Result> OrderPayment { get; set; }

	public decimal? RemainOrdAmount { get; set; }

	public decimal? SumOrdpayAmount { get; set; }

	public decimal? RemainOlderordsAmount { get; set; }

	public WSfnReturnOrderSumFooter_Result FooterData { get; set; }

	public string OrderUserName { get; set; }

	public string OrderInfo { get; set; }

	public int? OrderId { get; set; }

	public string DocInformation { get; set; }

	public int? DocId { get; set; }

	public int? OprType { get; set; }

	public int WareHouseCount { get; set; }

	public decimal? SumPricePartI { get; set; }

	public decimal? SumPricePartII { get; set; }

	public decimal? SumCommAmount { get; set; }

	public WSspSelectVerificationWorkFlowStepLast_Result LastVerificationStep { get; set; }

	public List<WSspReturnDocForSaleOrder_Result> DocList { get; set; }

	public bool isDecimal { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public string ordLinkAccFirstTransferDateStr { get; set; }

	public string ordLinkAccLastTransferDateStr { get; set; }

	public string TspOrdIdentify { get; set; }

	public string TspOrdInno { get; set; }

	public string TspOrdIns { get; set; }

	public string TspOrdSendDatePersian { get; set; }

	public string TspOrdUID { get; set; }

	public string TspOrdReferenceNumber { get; set; }

	public string TspOrdStatus { get; set; }

	public string TspOrdStatusResult { get; set; }

	public string TspOrdSendTypeTitle { get; set; }

	public WSspReturnSumOrderPay_Result FooterPay { get; set; }

	public string KaraAfzar_SmsPanelUserName { get; set; }

	public List<WSspReturnBuyOrderFromOrder_Result> BuyOrderList { get; set; }

	public string ordLinkAccData { get; set; }

	public bool IsSentToLinkAcc { get; set; }
}
