using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsWebOne;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetBatchDelivery", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class GetBatchDeliveryRequest
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public string userName;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public string password;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public int batchSmsId;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 3)]
	public int index;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 4)]
	public int count;

	public GetBatchDeliveryRequest()
	{
	}

	public GetBatchDeliveryRequest(string userName, string password, int batchSmsId, int index, int count)
	{
		this.userName = userName;
		this.password = password;
		this.batchSmsId = batchSmsId;
		this.index = index;
		this.count = count;
	}
}
