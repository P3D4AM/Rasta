using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomersBaseInfoResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomersBaseInfoResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfCustomer GetCustomersBaseInfoResult;

	public GetCustomersBaseInfoResponse()
	{
	}

	public GetCustomersBaseInfoResponse(ResponseDataOfCustomer GetCustomersBaseInfoResult)
	{
		this.GetCustomersBaseInfoResult = GetCustomersBaseInfoResult;
	}
}
