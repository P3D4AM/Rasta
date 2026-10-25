using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class RequestKalaRequest
{
	[MessageBodyMember(Name = "RequestKala", Namespace = "http://tempuri.org/", Order = 0)]
	public RequestKalaRequestBody Body;

	public RequestKalaRequest()
	{
	}

	public RequestKalaRequest(RequestKalaRequestBody Body)
	{
		this.Body = Body;
	}
}
