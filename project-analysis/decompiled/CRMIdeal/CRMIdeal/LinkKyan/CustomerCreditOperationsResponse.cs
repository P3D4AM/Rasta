using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "CustomerCreditOperationsResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class CustomerCreditOperationsResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfString CustomerCreditOperationsResult;

	public CustomerCreditOperationsResponse()
	{
	}

	public CustomerCreditOperationsResponse(ResponseDataOfString CustomerCreditOperationsResult)
	{
		this.CustomerCreditOperationsResult = CustomerCreditOperationsResult;
	}
}
