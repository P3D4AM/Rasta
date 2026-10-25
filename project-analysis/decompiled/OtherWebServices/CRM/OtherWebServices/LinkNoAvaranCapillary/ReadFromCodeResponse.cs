using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromCodeResponse
{
	[MessageBodyMember(Name = "ReadFromCodeResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromCodeResponseBody Body;

	public ReadFromCodeResponse()
	{
	}

	public ReadFromCodeResponse(ReadFromCodeResponseBody Body)
	{
		this.Body = Body;
	}
}
