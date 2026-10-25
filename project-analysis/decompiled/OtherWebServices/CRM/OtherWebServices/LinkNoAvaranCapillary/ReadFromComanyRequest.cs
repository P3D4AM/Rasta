using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromComanyRequest
{
	[MessageBodyMember(Name = "ReadFromComany", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromComanyRequestBody Body;

	public ReadFromComanyRequest()
	{
	}

	public ReadFromComanyRequest(ReadFromComanyRequestBody Body)
	{
		this.Body = Body;
	}
}
