using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetBatchDeliveryResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class GetBatchDeliveryResponse
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public int GetBatchDeliveryResult;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public string[] numbers;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public int[] deliveryStatus;

	public GetBatchDeliveryResponse()
	{
	}

	public GetBatchDeliveryResponse(int GetBatchDeliveryResult, string[] numbers, int[] deliveryStatus)
	{
		this.GetBatchDeliveryResult = GetBatchDeliveryResult;
		this.numbers = numbers;
		this.deliveryStatus = deliveryStatus;
	}
}
