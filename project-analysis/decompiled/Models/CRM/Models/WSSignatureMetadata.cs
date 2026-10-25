using System;

namespace CRM.Models;

public class WSSignatureMetadata
{
	public int SignatureID { get; set; }

	public byte[] Signature { get; set; }

	public string SignatureDescription { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
