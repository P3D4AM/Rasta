using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SendSMSResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class SendSMSResponse
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public int SendSMSResult;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public long[] recId;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public byte[] status;

	public SendSMSResponse()
	{
	}

	public SendSMSResponse(int SendSMSResult, long[] recId, byte[] status)
	{
		this.SendSMSResult = SendSMSResult;
		this.recId = recId;
		this.status = status;
	}
}
