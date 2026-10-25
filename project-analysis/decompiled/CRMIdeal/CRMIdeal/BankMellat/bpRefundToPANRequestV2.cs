using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.BankMellat;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class bpRefundToPANRequestV2
{
	[MessageBodyMember(Name = "bpRefundToPANRequestV2", Namespace = "http://interfaces.core.sw.bps.com/", Order = 0)]
	public bpRefundToPANRequestV2Body Body;

	public bpRefundToPANRequestV2()
	{
	}

	public bpRefundToPANRequestV2(bpRefundToPANRequestV2Body Body)
	{
		this.Body = Body;
	}
}
