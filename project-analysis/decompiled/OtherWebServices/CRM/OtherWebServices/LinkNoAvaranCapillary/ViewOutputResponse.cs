using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ViewOutputResponse
{
	[MessageBodyMember(Name = "ViewOutputResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ViewOutputResponseBody Body;

	public ViewOutputResponse()
	{
	}

	public ViewOutputResponse(ViewOutputResponseBody Body)
	{
		this.Body = Body;
	}
}
