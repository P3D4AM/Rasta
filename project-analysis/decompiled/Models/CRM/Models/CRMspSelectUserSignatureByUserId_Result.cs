namespace CRM.Models;

public class CRMspSelectUserSignatureByUserId_Result
{
	public int SignatureID { get; set; }

	public int SignatureUserId { get; set; }

	public byte[] Signature { get; set; }
}
