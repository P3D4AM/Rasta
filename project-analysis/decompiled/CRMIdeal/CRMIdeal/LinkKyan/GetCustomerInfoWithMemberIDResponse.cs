using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomerInfoWithMemberIDResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerInfoWithMemberIDResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfCustomer GetCustomerInfoWithMemberIDResult;

	public GetCustomerInfoWithMemberIDResponse()
	{
	}

	public GetCustomerInfoWithMemberIDResponse(ResponseDataOfCustomer GetCustomerInfoWithMemberIDResult)
	{
		this.GetCustomerInfoWithMemberIDResult = GetCustomerInfoWithMemberIDResult;
	}
}
