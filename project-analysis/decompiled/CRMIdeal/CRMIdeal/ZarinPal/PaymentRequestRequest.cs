using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class PaymentRequestRequest
{
	[MessageBodyMember(Name = "PaymentRequest", Namespace = "http://zarinpal.com/", Order = 0)]
	public PaymentRequestRequestBody Body;

	public PaymentRequestRequest()
	{
	}

	public PaymentRequestRequest(PaymentRequestRequestBody Body)
	{
		this.Body = Body;
	}
}
