using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpRefundToPANRequest
{
	[MessageBodyMember(Name = "bpRefundToPANRequest", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpRefundToPANRequestBody Body;

	public bpRefundToPANRequest()
	{
	}

	public bpRefundToPANRequest(bpRefundToPANRequestBody Body)
	{
		this.Body = Body;
	}
}
