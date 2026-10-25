using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromActionRequest
{
	[MessageBodyMember(Name = "ReadFromAction", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromActionRequestBody Body;

	public ReadFromActionRequest()
	{
	}

	public ReadFromActionRequest(ReadFromActionRequestBody Body)
	{
		this.Body = Body;
	}
}
