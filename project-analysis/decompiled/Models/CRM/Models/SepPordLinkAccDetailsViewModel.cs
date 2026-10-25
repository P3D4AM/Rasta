using System.Collections.Generic;

namespace CRM.Models;

public class SepPordLinkAccDetailsViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public CRMspLkSepWSSelectPreOrderByPordId_Result PreOrderInfo { get; set; }

	public List<CRMspLkSepWSSelectPreOrderItemsByPordId_Result> PreOrderItems { get; set; }

	public List<CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result> PreOrderPayments { get; set; }
}
