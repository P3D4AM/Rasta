using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsTehranPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "getCreditPrice", WrapperNamespace = "urn:SMSwsdl", IsWrapped = true)]
public class getCreditPriceRequest
{
	[MessageBodyMember(Namespace = "", Order = 0)]
	public string domain;

	[MessageBodyMember(Namespace = "", Order = 1)]
	public string username;

	[MessageBodyMember(Namespace = "", Order = 2)]
	public string password;

	[MessageBodyMember(Namespace = "", Order = 3)]
	public string amount;

	public getCreditPriceRequest()
	{
	}

	public getCreditPriceRequest(string domain, string username, string password, string amount)
	{
		this.domain = domain;
		this.username = username;
		this.password = password;
		this.amount = amount;
	}
}
