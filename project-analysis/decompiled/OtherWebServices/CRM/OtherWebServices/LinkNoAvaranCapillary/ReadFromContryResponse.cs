using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromContryResponse
{
	[MessageBodyMember(Name = "ReadFromContryResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromContryResponseBody Body;

	public ReadFromContryResponse()
	{
	}

	public ReadFromContryResponse(ReadFromContryResponseBody Body)
	{
		this.Body = Body;
	}
}
