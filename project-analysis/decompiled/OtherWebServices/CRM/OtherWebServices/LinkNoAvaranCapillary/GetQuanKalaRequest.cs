using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetQuanKalaRequest
{
	[MessageBodyMember(Name = "GetQuanKala", Namespace = "http://tempuri.org/", Order = 0)]
	public GetQuanKalaRequestBody Body;

	public GetQuanKalaRequest()
	{
	}

	public GetQuanKalaRequest(GetQuanKalaRequestBody Body)
	{
		this.Body = Body;
	}
}
