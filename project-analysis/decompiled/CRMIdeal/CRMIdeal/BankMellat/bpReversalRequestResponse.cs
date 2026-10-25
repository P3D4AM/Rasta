using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpReversalRequestResponse
{
	[MessageBodyMember(Name = "bpReversalRequestResponse", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpReversalRequestResponseBody Body;

	public bpReversalRequestResponse()
	{
	}

	public bpReversalRequestResponse(bpReversalRequestResponseBody Body)
	{
		this.Body = Body;
	}
}
