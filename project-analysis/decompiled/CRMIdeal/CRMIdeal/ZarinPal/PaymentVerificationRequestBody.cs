using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DataContract(Namespace = "http://zarinpal.com/")]
public class PaymentVerificationRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string MerchantID;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Authority;

	[DataMember(Order = 2)]
	public int Amount;

	public PaymentVerificationRequestBody()
	{
	}

	public PaymentVerificationRequestBody(string MerchantID, string Authority, int Amount)
	{
		this.MerchantID = MerchantID;
		this.Authority = Authority;
		this.Amount = Amount;
	}
}
