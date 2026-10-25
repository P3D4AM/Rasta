using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpVerifyRequest
{
	[MessageBodyMember(Name = "bpVerifyRequest", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpVerifyRequestBody Body;

	public bpVerifyRequest()
	{
	}

	public bpVerifyRequest(bpVerifyRequestBody Body)
	{
		this.Body = Body;
	}
}
