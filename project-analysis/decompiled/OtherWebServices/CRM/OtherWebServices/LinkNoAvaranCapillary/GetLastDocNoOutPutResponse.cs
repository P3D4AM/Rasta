using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetLastDocNoOutPutResponse
{
	[MessageBodyMember(Name = "GetLastDocNoOutPutResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public GetLastDocNoOutPutResponseBody Body;

	public GetLastDocNoOutPutResponse()
	{
	}

	public GetLastDocNoOutPutResponse(GetLastDocNoOutPutResponseBody Body)
	{
		this.Body = Body;
	}
}
