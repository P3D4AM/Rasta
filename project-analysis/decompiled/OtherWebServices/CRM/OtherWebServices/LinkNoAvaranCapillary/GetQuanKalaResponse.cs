using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetQuanKalaResponse
{
	[MessageBodyMember(Name = "GetQuanKalaResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public GetQuanKalaResponseBody Body;

	public GetQuanKalaResponse()
	{
	}

	public GetQuanKalaResponse(GetQuanKalaResponseBody Body)
	{
		this.Body = Body;
	}
}
