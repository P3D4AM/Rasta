using System;

namespace CRM.Models;

public class UserSignatureViewModel
{
	public int SignatureID { get; set; }

	public int SignatureUserId { get; set; }

	public string Signature { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string AppType { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
