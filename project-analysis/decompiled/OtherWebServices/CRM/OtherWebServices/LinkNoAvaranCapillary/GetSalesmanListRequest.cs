using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetSalesmanListRequest
{
	[MessageBodyMember(Name = "GetSalesmanList", Namespace = "http://tempuri.org/", Order = 0)]
	public GetSalesmanListRequestBody Body;

	public GetSalesmanListRequest()
	{
	}

	public GetSalesmanListRequest(GetSalesmanListRequestBody Body)
	{
		this.Body = Body;
	}
}
