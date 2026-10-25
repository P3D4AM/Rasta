using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetUsedCreditCustomerResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetUsedCreditCustomerResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfUsedCreditCustomer GetUsedCreditCustomerResult;

	public GetUsedCreditCustomerResponse()
	{
	}

	public GetUsedCreditCustomerResponse(ResponseDataOfUsedCreditCustomer GetUsedCreditCustomerResult)
	{
		this.GetUsedCreditCustomerResult = GetUsedCreditCustomerResult;
	}
}
