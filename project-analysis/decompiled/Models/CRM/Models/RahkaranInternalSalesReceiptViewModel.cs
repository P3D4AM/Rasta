using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesReceiptViewModel
{
	public long? BranchID { get; set; }

	public long? CashID { get; set; }

	public string CounterPartDLCode { get; set; }

	public string Date { get; set; }

	public string Description { get; set; }

	public string Description_En { get; set; }

	public bool? IsApproved { get; set; }

	public string Number { get; set; }

	public List<RahkaranInternalSalesReceiptCashMoneysViewModel> ReceiptCashMoneys { get; set; }

	public List<RahkaranInternalSalesReceiptDepositsViewModel> ReceiptDeposits { get; set; }

	public List<RahkaranInternalSalesReceiptReceivableChequesViewModel> ReceiptReceivableCheques { get; set; }

	public string SecondNumber { get; set; }
}
