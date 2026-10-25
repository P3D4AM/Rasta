using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsTehranPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "getPayAccounts", WrapperNamespace = "urn:SMSwsdl", IsWrapped = true)]
public class getPayAccountsRequest
{
	[MessageBodyMember(Namespace = "", Order = 0)]
	public string domain;

	[MessageBodyMember(Namespace = "", Order = 1)]
	public string username;

	[MessageBodyMember(Namespace = "", Order = 2)]
	public string password;

	public getPayAccountsRequest()
	{
	}

	public getPayAccountsRequest(string domain, string username, string password)
	{
		this.domain = domain;
		this.username = username;
		this.password = password;
	}
}
