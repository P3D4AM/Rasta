using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromSalesmanGroupResponse
{
	[MessageBodyMember(Name = "ReadFromSalesmanGroupResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromSalesmanGroupResponseBody Body;

	public ReadFromSalesmanGroupResponse()
	{
	}

	public ReadFromSalesmanGroupResponse(ReadFromSalesmanGroupResponseBody Body)
	{
		this.Body = Body;
	}
}
