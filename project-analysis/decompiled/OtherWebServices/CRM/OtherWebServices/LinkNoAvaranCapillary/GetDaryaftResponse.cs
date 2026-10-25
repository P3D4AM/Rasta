using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetDaryaftResponse
{
	[MessageBodyMember(Name = "GetDaryaftResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public GetDaryaftResponseBody Body;

	public GetDaryaftResponse()
	{
	}

	public GetDaryaftResponse(GetDaryaftResponseBody Body)
	{
		this.Body = Body;
	}
}
