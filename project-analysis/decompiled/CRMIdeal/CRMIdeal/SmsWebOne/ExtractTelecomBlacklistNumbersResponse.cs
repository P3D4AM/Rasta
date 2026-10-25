using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "ExtractTelecomBlacklistNumbersResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class ExtractTelecomBlacklistNumbersResponse
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public int ExtractTelecomBlacklistNumbersResult;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public string[] blacklistNumbers;

	public ExtractTelecomBlacklistNumbersResponse()
	{
	}

	public ExtractTelecomBlacklistNumbersResponse(int ExtractTelecomBlacklistNumbersResult, string[] blacklistNumbers)
	{
		this.ExtractTelecomBlacklistNumbersResult = ExtractTelecomBlacklistNumbersResult;
		this.blacklistNumbers = blacklistNumbers;
	}
}
