using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadAmvalRequest
{
	[MessageBodyMember(Name = "ReadAmval", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadAmvalRequestBody Body;

	public ReadAmvalRequest()
	{
	}

	public ReadAmvalRequest(ReadAmvalRequestBody Body)
	{
		this.Body = Body;
	}
}
