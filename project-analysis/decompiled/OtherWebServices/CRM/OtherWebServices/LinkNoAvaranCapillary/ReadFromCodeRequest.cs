using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromCodeRequest
{
	[MessageBodyMember(Name = "ReadFromCode", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromCodeRequestBody Body;

	public ReadFromCodeRequest()
	{
	}

	public ReadFromCodeRequest(ReadFromCodeRequestBody Body)
	{
		this.Body = Body;
	}
}
