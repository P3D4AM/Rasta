using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromComanyResponse
{
	[MessageBodyMember(Name = "ReadFromComanyResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromComanyResponseBody Body;

	public ReadFromComanyResponse()
	{
	}

	public ReadFromComanyResponse(ReadFromComanyResponseBody Body)
	{
		this.Body = Body;
	}
}
