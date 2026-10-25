using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpRefundRequest
{
	[MessageBodyMember(Name = "bpRefundRequest", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpRefundRequestBody Body;

	public bpRefundRequest()
	{
	}

	public bpRefundRequest(bpRefundRequestBody Body)
	{
		this.Body = Body;
	}
}
