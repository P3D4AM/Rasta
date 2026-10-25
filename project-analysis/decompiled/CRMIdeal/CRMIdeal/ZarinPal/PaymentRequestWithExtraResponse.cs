using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class PaymentRequestWithExtraResponse
{
	[MessageBodyMember(Name = "PaymentRequestWithExtraResponse", Namespace = "http://zarinpal.com/", Order = 0)]
	public PaymentRequestWithExtraResponseBody Body;

	public PaymentRequestWithExtraResponse()
	{
	}

	public PaymentRequestWithExtraResponse(PaymentRequestWithExtraResponseBody Body)
	{
		this.Body = Body;
	}
}
