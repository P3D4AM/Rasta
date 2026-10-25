namespace Mobile.Models;

public class MobspSelectUserSignatureByUserId_Result
{
	public int SignatureID { get; set; }

	public int SignatureUserId { get; set; }

	public byte[] Signature { get; set; }
}
