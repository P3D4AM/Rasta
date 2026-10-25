using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DataContract(Namespace = "http://zarinpal.com/")]
public class PaymentVerificationResponseBody
{
	[DataMember(Order = 0)]
	public int Status;

	[DataMember(Order = 1)]
	public long RefID;

	public PaymentVerificationResponseBody()
	{
	}

	public PaymentVerificationResponseBody(int Status, long RefID)
	{
		this.Status = Status;
		this.RefID = RefID;
	}
}
