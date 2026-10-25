using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpVerifySettleRequest
{
	[MessageBodyMember(Name = "bpVerifySettleRequest", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpVerifySettleRequestBody Body;

	public bpVerifySettleRequest()
	{
	}

	public bpVerifySettleRequest(bpVerifySettleRequestBody Body)
	{
		this.Body = Body;
	}
}
