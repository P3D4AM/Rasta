using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class RequestResponse
{
	[MessageBodyMember(Name = "RequestResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public RequestResponseBody Body;

	public RequestResponse()
	{
	}

	public RequestResponse(RequestResponseBody Body)
	{
		this.Body = Body;
	}
}
