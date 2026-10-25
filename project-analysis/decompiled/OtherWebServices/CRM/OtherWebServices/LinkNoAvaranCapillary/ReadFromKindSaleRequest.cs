using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromKindSaleRequest
{
	[MessageBodyMember(Name = "ReadFromKindSale", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromKindSaleRequestBody Body;

	public ReadFromKindSaleRequest()
	{
	}

	public ReadFromKindSaleRequest(ReadFromKindSaleRequestBody Body)
	{
		this.Body = Body;
	}
}
