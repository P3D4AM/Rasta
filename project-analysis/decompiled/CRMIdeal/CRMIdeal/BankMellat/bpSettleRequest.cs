using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpSettleRequest
{
	[MessageBodyMember(Name = "bpSettleRequest", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpSettleRequestBody Body;

	public bpSettleRequest()
	{
	}

	public bpSettleRequest(bpSettleRequestBody Body)
	{
		this.Body = Body;
	}
}
