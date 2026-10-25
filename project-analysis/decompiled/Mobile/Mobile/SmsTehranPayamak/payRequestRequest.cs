using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsTehranPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "payRequest", WrapperNamespace = "urn:SMSwsdl", IsWrapped = true)]
public class payRequestRequest
{
	[MessageBodyMember(Namespace = "", Order = 0)]
	public string domain;

	[MessageBodyMember(Namespace = "", Order = 1)]
	public string username;

	[MessageBodyMember(Namespace = "", Order = 2)]
	public string password;

	[MessageBodyMember(Namespace = "", Order = 3)]
	public string account;

	[MessageBodyMember(Namespace = "", Order = 4)]
	public string amount;

	[MessageBodyMember(Namespace = "", Order = 5)]
	public string r_url;

	public payRequestRequest()
	{
	}

	public payRequestRequest(string domain, string username, string password, string account, string amount, string r_url)
	{
		this.domain = domain;
		this.username = username;
		this.password = password;
		this.account = account;
		this.amount = amount;
		this.r_url = r_url;
	}
}
