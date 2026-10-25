using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromStoreResponse
{
	[MessageBodyMember(Name = "ReadFromStoreResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromStoreResponseBody Body;

	public ReadFromStoreResponse()
	{
	}

	public ReadFromStoreResponse(ReadFromStoreResponseBody Body)
	{
		this.Body = Body;
	}
}
