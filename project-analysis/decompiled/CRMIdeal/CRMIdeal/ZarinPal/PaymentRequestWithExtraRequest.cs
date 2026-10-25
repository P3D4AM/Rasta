using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class PaymentRequestWithExtraRequest
{
	[MessageBodyMember(Name = "PaymentRequestWithExtra", Namespace = "http://zarinpal.com/", Order = 0)]
	public PaymentRequestWithExtraRequestBody Body;

	public PaymentRequestWithExtraRequest()
	{
	}

	public PaymentRequestWithExtraRequest(PaymentRequestWithExtraRequestBody Body)
	{
		this.Body = Body;
	}
}
