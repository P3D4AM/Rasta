using System.Collections.Generic;

namespace CRM.Models;

public class SepBordLinkAccDetailsViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public CRMspLkSepWSSelectBuyOrderByBordId_Result BuyOrderInfo { get; set; }

	public List<CRMspLkSepWSSelectBuyOrderItemsByBordId_Result> BuyOrderItems { get; set; }

	public List<CRMspLkSepWSSelectBuyOrderPaymentsByBordId_Result> BuyOrderPayments { get; set; }
}
