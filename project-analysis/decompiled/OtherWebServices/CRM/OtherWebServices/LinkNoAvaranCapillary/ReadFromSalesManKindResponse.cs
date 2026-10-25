using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromSalesManKindResponse
{
	[MessageBodyMember(Name = "ReadFromSalesManKindResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromSalesManKindResponseBody Body;

	public ReadFromSalesManKindResponse()
	{
	}

	public ReadFromSalesManKindResponse(ReadFromSalesManKindResponseBody Body)
	{
		this.Body = Body;
	}
}
