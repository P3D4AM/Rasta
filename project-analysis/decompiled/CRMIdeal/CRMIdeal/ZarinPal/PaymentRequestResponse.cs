using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class PaymentRequestResponse
{
	[MessageBodyMember(Name = "PaymentRequestResponse", Namespace = "http://zarinpal.com/", Order = 0)]
	public PaymentRequestResponseBody Body;

	public PaymentRequestResponse()
	{
	}

	public PaymentRequestResponse(PaymentRequestResponseBody Body)
	{
		this.Body = Body;
	}
}
