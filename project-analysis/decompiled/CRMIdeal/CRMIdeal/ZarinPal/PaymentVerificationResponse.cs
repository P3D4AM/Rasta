using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class PaymentVerificationResponse
{
	[MessageBodyMember(Name = "PaymentVerificationResponse", Namespace = "http://zarinpal.com/", Order = 0)]
	public PaymentVerificationResponseBody Body;

	public PaymentVerificationResponse()
	{
	}

	public PaymentVerificationResponse(PaymentVerificationResponseBody Body)
	{
		this.Body = Body;
	}
}
