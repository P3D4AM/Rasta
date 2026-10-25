using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SendBatchSmsResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class SendBatchSmsResponse
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public int SendBatchSmsResult;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public int batchSmsId;

	public SendBatchSmsResponse()
	{
	}

	public SendBatchSmsResponse(int SendBatchSmsResult, int batchSmsId)
	{
		this.SendBatchSmsResult = SendBatchSmsResult;
		this.batchSmsId = batchSmsId;
	}
}
