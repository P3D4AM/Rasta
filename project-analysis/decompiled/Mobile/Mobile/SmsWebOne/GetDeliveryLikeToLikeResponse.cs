using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetDeliveryLikeToLikeResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class GetDeliveryLikeToLikeResponse
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public int GetDeliveryLikeToLikeResult;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public string[] numbers;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public int[] deliveryStatus;

	public GetDeliveryLikeToLikeResponse()
	{
	}

	public GetDeliveryLikeToLikeResponse(int GetDeliveryLikeToLikeResult, string[] numbers, int[] deliveryStatus)
	{
		this.GetDeliveryLikeToLikeResult = GetDeliveryLikeToLikeResult;
		this.numbers = numbers;
		this.deliveryStatus = deliveryStatus;
	}
}
