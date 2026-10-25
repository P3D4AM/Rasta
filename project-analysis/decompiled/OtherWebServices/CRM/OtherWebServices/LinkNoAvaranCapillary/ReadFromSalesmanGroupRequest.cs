using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromSalesmanGroupRequest
{
	[MessageBodyMember(Name = "ReadFromSalesmanGroup", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromSalesmanGroupRequestBody Body;

	public ReadFromSalesmanGroupRequest()
	{
	}

	public ReadFromSalesmanGroupRequest(ReadFromSalesmanGroupRequestBody Body)
	{
		this.Body = Body;
	}
}
