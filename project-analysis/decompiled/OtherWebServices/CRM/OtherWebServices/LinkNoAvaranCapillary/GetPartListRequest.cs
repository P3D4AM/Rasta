using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetPartListRequest
{
	[MessageBodyMember(Name = "GetPartList", Namespace = "http://tempuri.org/", Order = 0)]
	public GetPartListRequestBody Body;

	public GetPartListRequest()
	{
	}

	public GetPartListRequest(GetPartListRequestBody Body)
	{
		this.Body = Body;
	}
}
