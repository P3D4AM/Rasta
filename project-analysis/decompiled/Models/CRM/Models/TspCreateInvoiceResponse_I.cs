using System.Collections.Generic;

namespace CRM.Models;

public class TspCreateInvoiceResponse_I
{
	public string ConfirmationReferenceId { get; set; }

	public List<TspInvoiceErrorModel_I> Error { get; set; }

	public List<TspInvoiceErrorModel_I> Warning { get; set; }

	public bool Success { get; set; } = true;

}
