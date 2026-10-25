using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetRouteListResponse
{
	[MessageBodyMember(Name = "GetRouteListResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public GetRouteListResponseBody Body;

	public GetRouteListResponse()
	{
	}

	public GetRouteListResponse(GetRouteListResponseBody Body)
	{
		this.Body = Body;
	}
}
