using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SendSmsLikeToLikeResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class SendSmsLikeToLikeResponse
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public int SendSmsLikeToLikeResult;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public int smsId;

	public SendSmsLikeToLikeResponse()
	{
	}

	public SendSmsLikeToLikeResponse(int SendSmsLikeToLikeResult, int smsId)
	{
		this.SendSmsLikeToLikeResult = SendSmsLikeToLikeResult;
		this.smsId = smsId;
	}
}
