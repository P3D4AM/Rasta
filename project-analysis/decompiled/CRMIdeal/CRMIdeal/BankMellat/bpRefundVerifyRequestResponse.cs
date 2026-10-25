using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpRefundVerifyRequestResponse
{
	[MessageBodyMember(Name = "bpRefundVerifyRequestResponse", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpRefundVerifyRequestResponseBody Body;

	public bpRefundVerifyRequestResponse()
	{
	}

	public bpRefundVerifyRequestResponse(bpRefundVerifyRequestResponseBody Body)
	{
		this.Body = Body;
	}
}
