using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class PaymentVerificationWithExtraRequest
{
	[MessageBodyMember(Name = "PaymentVerificationWithExtra", Namespace = "http://zarinpal.com/", Order = 0)]
	public PaymentVerificationWithExtraRequestBody Body;

	public PaymentVerificationWithExtraRequest()
	{
	}

	public PaymentVerificationWithExtraRequest(PaymentVerificationWithExtraRequestBody Body)
	{
		this.Body = Body;
	}
}
