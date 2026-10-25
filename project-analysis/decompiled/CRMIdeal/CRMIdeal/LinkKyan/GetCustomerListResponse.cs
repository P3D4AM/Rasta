using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomerListResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerListResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfCustomer GetCustomerListResult;

	public GetCustomerListResponse()
	{
	}

	public GetCustomerListResponse(ResponseDataOfCustomer GetCustomerListResult)
	{
		this.GetCustomerListResult = GetCustomerListResult;
	}
}
