using System.Collections.Generic;

namespace CRM.Models;

public class TSPInvoiceRequest
{
	public TSPInvoiceHedaerRequest header { get; set; }

	public List<TSPInvoiceBodyRequest> body { get; set; }

	public List<TSPInvoicePaymentRequest> payments { get; set; }
}
