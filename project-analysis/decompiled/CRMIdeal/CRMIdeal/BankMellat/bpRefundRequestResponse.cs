using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpRefundRequestResponse
{
	[MessageBodyMember(Name = "bpRefundRequestResponse", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpRefundRequestResponseBody Body;

	public bpRefundRequestResponse()
	{
	}

	public bpRefundRequestResponse(bpRefundRequestResponseBody Body)
	{
		this.Body = Body;
	}
}
