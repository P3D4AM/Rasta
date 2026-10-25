using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromRequestRequest
{
	[MessageBodyMember(Name = "ReadFromRequest", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromRequestRequestBody Body;

	public ReadFromRequestRequest()
	{
	}

	public ReadFromRequestRequest(ReadFromRequestRequestBody Body)
	{
		this.Body = Body;
	}
}
