using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "UpdateCustomerInfoResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class UpdateCustomerInfoResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfCustomer UpdateCustomerInfoResult;

	public UpdateCustomerInfoResponse()
	{
	}

	public UpdateCustomerInfoResponse(ResponseDataOfCustomer UpdateCustomerInfoResult)
	{
		this.UpdateCustomerInfoResult = UpdateCustomerInfoResult;
	}
}
