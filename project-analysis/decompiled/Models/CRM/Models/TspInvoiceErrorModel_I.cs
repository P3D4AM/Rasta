using System.Collections.Generic;

namespace CRM.Models;

public class TspInvoiceErrorModel_I
{
	public string Code { get; set; }

	public string Msg { get; set; }

	public string Message { get; set; }

	public List<object> Detail { get; set; }
}
