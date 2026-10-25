using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DataContract(Namespace = "http://zarinpal.com/")]
public class PaymentVerificationWithExtraResponseBody
{
	[DataMember(Order = 0)]
	public int Status;

	[DataMember(Order = 1)]
	public long RefID;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string ExtraDetail;

	public PaymentVerificationWithExtraResponseBody()
	{
	}

	public PaymentVerificationWithExtraResponseBody(int Status, long RefID, string ExtraDetail)
	{
		this.Status = Status;
		this.RefID = RefID;
		this.ExtraDetail = ExtraDetail;
	}
}
