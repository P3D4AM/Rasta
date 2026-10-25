using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SendSmsLikeToLike", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class SendSmsLikeToLikeRequest
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
	public string[] messageContents;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 5)]
	public bool isFlash;

	public SendSmsLikeToLikeRequest()
	{
	}

	public SendSmsLikeToLikeRequest(string userName, string password, string fromNumber, string[] toNumbers, string[] messageContents, bool isFlash)
	{
		this.userName = userName;
		this.password = password;
		this.fromNumber = fromNumber;
		this.toNumbers = toNumbers;
		this.messageContents = messageContents;
		this.isFlash = isFlash;
	}
}
