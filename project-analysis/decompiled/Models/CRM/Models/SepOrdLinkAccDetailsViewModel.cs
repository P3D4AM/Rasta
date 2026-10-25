using System.Collections.Generic;

namespace CRM.Models;

public class SepOrdLinkAccDetailsViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public CRMspLkSepWSSelectOrderByOrdId_Result OrderInfo { get; set; }

	public List<CRMspLkSepWSSelectOrderItemsByOrdId_Result> OrderItems { get; set; }

	public List<CRMspLkSepWSSelectOrderPaymentsByOrdId_Result> OrderPayments { get; set; }

	public List<CRMspLkSepWSSelectOrderCommissionsByOrdId_Result> OrderCommissions { get; set; }
}
