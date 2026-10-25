using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class GetUnverifiedTransactionsRequest
{
	[MessageBodyMember(Name = "GetUnverifiedTransactions", Namespace = "http://zarinpal.com/", Order = 0)]
	public GetUnverifiedTransactionsRequestBody Body;

	public GetUnverifiedTransactionsRequest()
	{
	}

	public GetUnverifiedTransactionsRequest(GetUnverifiedTransactionsRequestBody Body)
	{
		this.Body = Body;
	}
}
