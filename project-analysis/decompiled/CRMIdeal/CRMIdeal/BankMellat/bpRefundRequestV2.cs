using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpRefundRequestV2
{
	[MessageBodyMember(Name = "bpRefundRequestV2", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpRefundRequestV2Body Body;

	public bpRefundRequestV2()
	{
	}

	public bpRefundRequestV2(bpRefundRequestV2Body Body)
	{
		this.Body = Body;
	}
}
