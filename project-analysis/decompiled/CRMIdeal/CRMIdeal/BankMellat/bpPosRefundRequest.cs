using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpPosRefundRequest
{
	[MessageBodyMember(Name = "bpPosRefundRequest", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpPosRefundRequestBody Body;

	public bpPosRefundRequest()
	{
	}

	public bpPosRefundRequest(bpPosRefundRequestBody Body)
	{
		this.Body = Body;
	}
}
