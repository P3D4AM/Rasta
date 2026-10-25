using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class PaymentVerificationWithExtraResponse
{
	[MessageBodyMember(Name = "PaymentVerificationWithExtraResponse", Namespace = "http://zarinpal.com/", Order = 0)]
	public PaymentVerificationWithExtraResponseBody Body;

	public PaymentVerificationWithExtraResponse()
	{
	}

	public PaymentVerificationWithExtraResponse(PaymentVerificationWithExtraResponseBody Body)
	{
		this.Body = Body;
	}
}
