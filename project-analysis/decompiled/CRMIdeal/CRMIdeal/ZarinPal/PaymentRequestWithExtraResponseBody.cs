using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DataContract(Namespace = "http://zarinpal.com/")]
public class PaymentRequestWithExtraResponseBody
{
	[DataMember(Order = 0)]
	public int Status;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Authority;

	public PaymentRequestWithExtraResponseBody()
	{
	}

	public PaymentRequestWithExtraResponseBody(int Status, string Authority)
	{
		this.Status = Status;
		this.Authority = Authority;
	}
}
