using System.Collections.Generic;

namespace CRM.Models;

public class CurrentPreOrderViewModel
{
	public WSspSelectPreOrdersInMode_Result PreOrder { get; set; }

	public int PreOrderCurrentId { get; set; }

	public int PreOrderNextId { get; set; }

	public int PreOrderPreviousId { get; set; }

	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public int CompanyId { get; set; }

	public long PreOrderNumber { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int PreOrderFirstId { get; set; }

	public int PreOrderLastId { get; set; }

	public List<PreOrderItemsViewModel> PreOrderItemsList { get; set; }

	public decimal? RemainpordAmount { get; set; }

	public decimal? sumpordpayAmount { get; set; }

	public decimal? AllPayRemain { get; set; }

	public WSfnReturnPreOrderSumFooter_Result FooterData { get; set; }

	public string OrderUserName { get; set; }

	public string OrderInfo { get; set; }

	public int? OrderId { get; set; }

	public decimal? NotInSumTotalPrice { get; set; }

	public WSspSelectVerificationWorkFlowStepLast_Result LastVerificationStep { get; set; }

	public decimal? SumCommAmount { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public string pordLinkAccFirstTransferDateStr { get; set; }

	public string pordLinkAccLastTransferDateStr { get; set; }

	public bool isDecimal { get; set; }

	public int? pordVerifierId { get; set; }

	public string pordNumRef { get; set; }

	public int? pordSellerId { get; set; }

	public string pordSellerName { get; set; }

	public List<WSspReturnOrderFromPreOrder_Result> OrdList { get; set; }

	public int WareHouseCount { get; set; }

	public List<WSspReturnDocFromPreOrder_Result> DocList { get; set; }

	public string DocInformation { get; set; }

	public int? DocId { get; set; }

	public int? OprType { get; set; }

	public WSspReturnSumPreOrderPay_Result FooterPay { get; set; }

	public List<WSspSelectPreOrderNumberRevision_Result> PordNumberRevisionList { get; set; }

	public string KaraAfzar_SmsPanelUserName { get; set; }

	public int? KaraAfzar_SmsPanelOrdId { get; set; }

	public int? KaraAfzar_SmsPanelOrdItemId { get; set; }

	public decimal? KaraAfzar_SmsPanelOrdItemPriceSum { get; set; }

	public int? PreOrderDiscountCount { get; set; }

	public List<WSspReturnStockSupplyFromPreOrder_Result> StockSupplyList { get; set; }

	public string pordLinkAccData { get; set; }

	public bool PordIsCanceled { get; set; }

	public bool IsSentToLinkAcc { get; set; }

	public bool IsExpired { get; set; }

	public string PordInfoInHead { get; set; }
}
