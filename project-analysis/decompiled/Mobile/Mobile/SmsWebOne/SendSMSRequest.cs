using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SendSMS", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class SendSMSRequest
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public string userName;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public string password;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public string fromNumber;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 3)]
	public string[] toNumbers;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 4)]
	public string messageContent;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 5)]
	public bool isFlash;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 6)]
	public long[] recId;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 7)]
	public byte[] status;

	public SendSMSRequest()
	{
	}

	public SendSMSRequest(string userName, string password, string fromNumber, string[] toNumbers, string messageContent, bool isFlash, long[] recId, byte[] status)
	{
		this.userName = userName;
		this.password = password;
		this.fromNumber = fromNumber;
		this.toNumbers = toNumbers;
		this.messageContent = messageContent;
		this.isFlash = isFlash;
		this.recId = recId;
		this.status = status;
	}
}
