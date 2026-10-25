using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class GetUnverifiedTransactionsResponse
{
	[MessageBodyMember(Name = "GetUnverifiedTransactionsResponse", Namespace = "http://zarinpal.com/", Order = 0)]
	public GetUnverifiedTransactionsResponseBody Body;

	public GetUnverifiedTransactionsResponse()
	{
	}

	public GetUnverifiedTransactionsResponse(GetUnverifiedTransactionsResponseBody Body)
	{
		this.Body = Body;
	}
}
