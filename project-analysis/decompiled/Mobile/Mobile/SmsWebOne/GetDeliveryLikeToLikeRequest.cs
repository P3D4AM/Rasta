using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetDeliveryLikeToLike", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class GetDeliveryLikeToLikeRequest
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public string userName;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public string password;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public int smsId;

	public GetDeliveryLikeToLikeRequest()
	{
	}

	public GetDeliveryLikeToLikeRequest(string userName, string password, int smsId)
	{
		this.userName = userName;
		this.password = password;
		this.smsId = smsId;
	}
}
