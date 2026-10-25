using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesPaymentViewModel
{
	public long? BranchID { get; set; }

	public long? CashID { get; set; }

	public string CounterPartDLCode { get; set; }

	public string Date { get; set; }

	public string Description { get; set; }

	public string Description_En { get; set; }

	public string Number { get; set; }

	public List<RahkaranInternalSalesPaymentCashMoneysViewModel> PaymentCashMoneys { get; set; }

	public List<RahkaranInternalSalesPaymentDepositsViewModel> PaymentDeposits { get; set; }

	public List<RahkaranInternalSalesPaymentPayableChequesViewModel> PaymentPayableCheques { get; set; }

	public string SecondNumber { get; set; }
}
