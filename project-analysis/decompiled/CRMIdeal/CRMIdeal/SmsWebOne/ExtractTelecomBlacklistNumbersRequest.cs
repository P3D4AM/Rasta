using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "ExtractTelecomBlacklistNumbers", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class ExtractTelecomBlacklistNumbersRequest
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public string userName;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public string password;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public string numbers;

	public ExtractTelecomBlacklistNumbersRequest()
	{
	}

	public ExtractTelecomBlacklistNumbersRequest(string userName, string password, string numbers)
	{
		this.userName = userName;
		this.password = password;
		this.numbers = numbers;
	}
}
