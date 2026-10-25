using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class PaymentVerificationRequest
{
	[MessageBodyMember(Name = "PaymentVerification", Namespace = "http://zarinpal.com/", Order = 0)]
	public PaymentVerificationRequestBody Body;

	public PaymentVerificationRequest()
	{
	}

	public PaymentVerificationRequest(PaymentVerificationRequestBody Body)
	{
		this.Body = Body;
	}
}
