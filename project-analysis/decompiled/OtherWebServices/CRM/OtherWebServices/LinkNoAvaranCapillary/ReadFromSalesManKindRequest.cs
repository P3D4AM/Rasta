using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromSalesManKindRequest
{
	[MessageBodyMember(Name = "ReadFromSalesManKind", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromSalesManKindRequestBody Body;

	public ReadFromSalesManKindRequest()
	{
	}

	public ReadFromSalesManKindRequest(ReadFromSalesManKindRequestBody Body)
	{
		this.Body = Body;
	}
}
