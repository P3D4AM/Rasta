using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomerAddressInfoWithCustomerIDResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerAddressInfoWithCustomerIDResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfCustomerAddress GetCustomerAddressInfoWithCustomerIDResult;

	public GetCustomerAddressInfoWithCustomerIDResponse()
	{
	}

	public GetCustomerAddressInfoWithCustomerIDResponse(ResponseDataOfCustomerAddress GetCustomerAddressInfoWithCustomerIDResult)
	{
		this.GetCustomerAddressInfoWithCustomerIDResult = GetCustomerAddressInfoWithCustomerIDResult;
	}
}
