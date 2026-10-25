using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromKindSaleResponse
{
	[MessageBodyMember(Name = "ReadFromKindSaleResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromKindSaleResponseBody Body;

	public ReadFromKindSaleResponse()
	{
	}

	public ReadFromKindSaleResponse(ReadFromKindSaleResponseBody Body)
	{
		this.Body = Body;
	}
}
