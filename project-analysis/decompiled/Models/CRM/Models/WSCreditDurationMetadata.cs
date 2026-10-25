using System;

namespace CRM.Models;

public class WSCreditDurationMetadata
{
	public int CreditDurationID { get; set; }

	public string CreditDuration { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
