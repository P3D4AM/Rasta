using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetDaryaftRequest
{
	[MessageBodyMember(Name = "GetDaryaft", Namespace = "http://tempuri.org/", Order = 0)]
	public GetDaryaftRequestBody Body;

	public GetDaryaftRequest()
	{
	}

	public GetDaryaftRequest(GetDaryaftRequestBody Body)
	{
		this.Body = Body;
	}
}
