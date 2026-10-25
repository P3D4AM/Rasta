using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetSalesmanListResponse
{
	[MessageBodyMember(Name = "GetSalesmanListResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public GetSalesmanListResponseBody Body;

	public GetSalesmanListResponse()
	{
	}

	public GetSalesmanListResponse(GetSalesmanListResponseBody Body)
	{
		this.Body = Body;
	}
}
