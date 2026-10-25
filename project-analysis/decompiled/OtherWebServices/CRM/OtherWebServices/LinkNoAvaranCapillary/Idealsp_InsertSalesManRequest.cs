using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertSalesManRequest
{
	[MessageBodyMember(Name = "Idealsp_InsertSalesMan", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertSalesManRequestBody Body;

	public Idealsp_InsertSalesManRequest()
	{
	}

	public Idealsp_InsertSalesManRequest(Idealsp_InsertSalesManRequestBody Body)
	{
		this.Body = Body;
	}
}
