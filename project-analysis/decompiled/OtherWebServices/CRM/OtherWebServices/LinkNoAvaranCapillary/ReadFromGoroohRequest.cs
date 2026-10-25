using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromGoroohRequest
{
	[MessageBodyMember(Name = "ReadFromGorooh", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromGoroohRequestBody Body;

	public ReadFromGoroohRequest()
	{
	}

	public ReadFromGoroohRequest(ReadFromGoroohRequestBody Body)
	{
		this.Body = Body;
	}
}
