using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class GetLastCodeCustomerResponse
{
	[MessageBodyMember(Name = "GetLastCodeCustomerResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public GetLastCodeCustomerResponseBody Body;

	public GetLastCodeCustomerResponse()
	{
	}

	public GetLastCodeCustomerResponse(GetLastCodeCustomerResponseBody Body)
	{
		this.Body = Body;
	}
}
