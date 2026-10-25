using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadAmvalResponse
{
	[MessageBodyMember(Name = "ReadAmvalResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadAmvalResponseBody Body;

	public ReadAmvalResponse()
	{
	}

	public ReadAmvalResponse(ReadAmvalResponseBody Body)
	{
		this.Body = Body;
	}
}
