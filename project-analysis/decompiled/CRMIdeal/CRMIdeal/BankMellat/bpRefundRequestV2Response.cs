using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpRefundRequestV2Response
{
	[MessageBodyMember(Name = "bpRefundRequestV2Response", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpRefundRequestV2ResponseBody Body;

	public bpRefundRequestV2Response()
	{
	}

	public bpRefundRequestV2Response(bpRefundRequestV2ResponseBody Body)
	{
		this.Body = Body;
	}
}
