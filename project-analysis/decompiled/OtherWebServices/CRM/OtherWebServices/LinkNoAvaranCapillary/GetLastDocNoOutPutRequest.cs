using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetLastDocNoOutPutRequest
{
	[MessageBodyMember(Name = "GetLastDocNoOutPut", Namespace = "http://tempuri.org/", Order = 0)]
	public GetLastDocNoOutPutRequestBody Body;

	public GetLastDocNoOutPutRequest()
	{
	}

	public GetLastDocNoOutPutRequest(GetLastDocNoOutPutRequestBody Body)
	{
		this.Body = Body;
	}
}
