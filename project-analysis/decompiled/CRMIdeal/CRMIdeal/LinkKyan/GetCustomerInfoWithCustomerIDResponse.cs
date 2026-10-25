using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomerInfoWithCustomerIDResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerInfoWithCustomerIDResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfCustomer GetCustomerInfoWithCustomerIDResult;

	public GetCustomerInfoWithCustomerIDResponse()
	{
	}

	public GetCustomerInfoWithCustomerIDResponse(ResponseDataOfCustomer GetCustomerInfoWithCustomerIDResult)
	{
		this.GetCustomerInfoWithCustomerIDResult = GetCustomerInfoWithCustomerIDResult;
	}
}
