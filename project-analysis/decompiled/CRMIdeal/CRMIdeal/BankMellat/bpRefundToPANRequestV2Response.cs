using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpRefundToPANRequestV2Response
{
	[MessageBodyMember(Name = "bpRefundToPANRequestV2Response", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpRefundToPANRequestV2ResponseBody Body;

	public bpRefundToPANRequestV2Response()
	{
	}

	public bpRefundToPANRequestV2Response(bpRefundToPANRequestV2ResponseBody Body)
	{
		this.Body = Body;
	}
}
