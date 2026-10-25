using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsTehranPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "getPayAccountsResponse", WrapperNamespace = "urn:SMSwsdl", IsWrapped = true)]
public class getPayAccountsResponse
{
	[MessageBodyMember(Namespace = "", Order = 0)]
	public string result;

	[MessageBodyMember(Namespace = "", Order = 1)]
	public account[] accounts;

	public getPayAccountsResponse()
	{
	}

	public getPayAccountsResponse(string result, account[] accounts)
	{
		this.result = result;
		this.accounts = accounts;
	}
}
