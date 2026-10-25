using System;

namespace CRM.Models;

public class ProductValidityIndicatorSendSmsResultViewModel
{
	public int OprId { get; set; }

	public int OprType { get; set; }

	public long OprNumber { get; set; }

	public string oprDate { get; set; }

	public DateTime? oprDateTime { get; set; }

	public string oprCompanyName { get; set; }

	public string oprReferUser { get; set; }

	public string OprName { get; set; }

	public string ErrorMessage { get; set; }
}
