using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsFaraPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetMultiDelivery", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class GetMultiDeliveryRequest
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public string recId;

	public GetMultiDeliveryRequest()
	{
	}

	public GetMultiDeliveryRequest(string recId)
	{
		this.recId = recId;
	}
}
