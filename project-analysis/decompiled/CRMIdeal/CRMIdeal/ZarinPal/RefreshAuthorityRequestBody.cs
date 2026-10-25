using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://zarinpal.com/")]
public class RefreshAuthorityRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string MerchantID;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Authority;

	[DataMember(Order = 2)]
	public int ExpireIn;

	public RefreshAuthorityRequestBody()
	{
	}

	public RefreshAuthorityRequestBody(string MerchantID, string Authority, int ExpireIn)
	{
		this.MerchantID = MerchantID;
		this.Authority = Authority;
		this.ExpireIn = ExpireIn;
	}
}
