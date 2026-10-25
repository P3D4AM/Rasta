using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertSalesManResponse
{
	[MessageBodyMember(Name = "Idealsp_InsertSalesManResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertSalesManResponseBody Body;

	public Idealsp_InsertSalesManResponse()
	{
	}

	public Idealsp_InsertSalesManResponse(Idealsp_InsertSalesManResponseBody Body)
	{
		this.Body = Body;
	}
}
