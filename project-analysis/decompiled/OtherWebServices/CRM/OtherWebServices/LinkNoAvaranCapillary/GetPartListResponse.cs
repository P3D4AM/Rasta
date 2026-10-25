using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetPartListResponse
{
	[MessageBodyMember(Name = "GetPartListResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public GetPartListResponseBody Body;

	public GetPartListResponse()
	{
	}

	public GetPartListResponse(GetPartListResponseBody Body)
	{
		this.Body = Body;
	}
}
