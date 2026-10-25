using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromActionResponse
{
	[MessageBodyMember(Name = "ReadFromActionResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromActionResponseBody Body;

	public ReadFromActionResponse()
	{
	}

	public ReadFromActionResponse(ReadFromActionResponseBody Body)
	{
		this.Body = Body;
	}
}
