using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromMaterialResponse
{
	[MessageBodyMember(Name = "ReadFromMaterialResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromMaterialResponseBody Body;

	public ReadFromMaterialResponse()
	{
	}

	public ReadFromMaterialResponse(ReadFromMaterialResponseBody Body)
	{
		this.Body = Body;
	}
}
